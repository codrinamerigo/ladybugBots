using myBots.Models;
using myBots.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace myBots.ViewModels
{
    public class BotViewModel: INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            private ObservableCollection<ConversationMessage> _messages;

            private string _textMessage;

            private bool _isRefreshing;

            private ICommand _sendMessageCommand;

            private ICommand _backCommand;

            private ChatBotService _chatBotService = new ChatBotService();

            public BotViewModel()
            {
                _messages = new ObservableCollection<ConversationMessage>();
                _messages.Add(new ConversationMessage
                {
                    Message = "Hi this is ladybug bot, how may I help you?",
                    FromUser = "LadyBug Bot",
                    UserImageUrl = "ladybugimg.png"
                });
            }

            public ObservableCollection<ConversationMessage> Messages
            {
                get { return _messages; }
                set
                {
                    _messages = value;
                    OnPropertyChanged("Messages");
                }
            }

            public string TextMessage
            {
                get { return _textMessage; }
                set
                {
                    _textMessage = value;
                    OnPropertyChanged("TextMessage");
                }
            }

            public ICommand SendMessageCommand
            {
                get
                {
                    return _sendMessageCommand = _sendMessageCommand ?? new Command(async () =>
                    {
                        Messages.Add(new ConversationMessage
                        {
                            FromUser = "User",
                            Message = TextMessage,
                            UserImageUrl = "user.png"
                        });

                        IsRefreshing = true;

                        var reply = await _chatBotService.SendMessage(TextMessage);

                        TextMessage = "";

                        Messages.Clear();

                        foreach (var msgItem in reply.Messages)
                        {
                            Messages.Add(new ConversationMessage
                            {
                                FromUser = msgItem.From == "myXamTestBot" ? "LadyBug Bot " : "User",
                                Message = msgItem.Text,
                                UserImageUrl = msgItem.From == "myXamTestBot" ? "ladybugimg.png" : "user.png" 
                            });
                        }

                        IsRefreshing = false;
                    });
                }
            }

            public bool IsRefreshing
            {
                get { return _isRefreshing; }
                set
                {
                    _isRefreshing = value;
                    OnPropertyChanged("IsRefreshing");
                }
            }


            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

