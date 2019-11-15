using Chat_Virtual___Cliente.Backend;
using Chat_Virtual___Cliente.Communication;
using DataStructures;
using ShippingData;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using static ShippingData.Message;

struct ControlParameters {
    //General
    public bool tabStop;
    public string name;
    public Size size;
    public AnchorStyles anchor;
    public Point location;
    //Para panel
    public BorderStyle borderStyle;
    //Para picture box
    public Image image;
    public PictureBoxSizeMode pictureBoxSizeMode;
    //Para label
    public string text;
    public ContentAlignment contentAlignment;
    //Para panel y label
    public bool autoSize;
    public Font font;
    public Color foreColor;
    public Color backColor;
};

enum CurrentView {
    InChat, InGroup, InHome, InProfile, ViewChats, ViewGroups, SearchingChats, SearchingGroups
};

namespace Chat_Virtual___Cliente.Frontend {
    public partial class HomeView : Form {

        private bool maximized;
        private bool subprocess;
        private MainModel model;
        private ShippingData.Message FirstMessage;
        private CurrentView currentView;

        private LinkedList<Control> AditionalComponents;
        private LinkedStack<Panel> RecentMessages;
        private LinkedStack<Panel> OldMessages;
        private DynamicArray<Panel> ActiveChats;

        private delegate void AddIn(Control toAdd, Control In);
        private delegate void AddIn2(Control toAdd, Control In);
        private delegate void DeleteIn(Control toAdd, Control In);
        private delegate void DeleteIn2(Control toAdd, Control In);
        private delegate void CopyParametersOf(Control controlOne, ControlParameters controlTwo);
        private delegate void ChangeImageOf(PictureBox pb, Image image);

        //Semaforos
        private Semaphore SActiveChats;
        private Semaphore SAditionalComponents;

        public HomeView() {
            InitializeComponent();
            model = new MainModel();
            maximized = false;
            subprocess = true;
            AditionalComponents = new LinkedList<Control>();
            RecentMessages = OldMessages = new LinkedStack<Panel>();
            ActiveChats = new DynamicArray<Panel>();
            SActiveChats = new Semaphore(1, 1);
            SAditionalComponents = new Semaphore(1, 1);
            FirstMessage = null;
            this.currentView = CurrentView.InHome;
            receptor.RunWorkerAsync();
        }

        //Estado: Listo
        private void MinButton_Click(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
        }

        //Estado: Listo
        private void MinButton_MouseEnter(object sender, EventArgs e) {
            minButtonPanel.BackColor = Color.FromArgb(100, 100, 100);
        }

        //Estado: Listo
        private void MinButton_MouseLeave(object sender, EventArgs e) {
            minButtonPanel.BackColor = topPane.BackColor;
        }

        //Estado: Listo
        private void ResizeButton_Click(object sender, EventArgs e) {
            if (maximized) {
                WindowState = FormWindowState.Normal;
                resizeButton.Image = global::Chat_Virtual___Cliente.Properties.Resources.Maximize_Window_2_48px;
            } else {
                WindowState = FormWindowState.Maximized;
                resizeButton.Image = global::Chat_Virtual___Cliente.Properties.Resources.Restore_Window_2_48px;
            }
            maximized = !maximized;
        }

        //Estado: Listo
        private void ResizeButton_MouseEnter(object sender, EventArgs e) {
            resizeButtonPanel.BackColor = Color.FromArgb(100, 100, 100);
        }

        //Estado: Listo
        private void ResizeButton_MouseLeave(object sender, EventArgs e) {
            resizeButtonPanel.BackColor = topPane.BackColor;
        }

        //Estado: Listo
        private void ExitButton_Click(object sender, EventArgs e) {
            model.Disconnect();
            subprocess = false;
            Application.Exit();
        }

        //Estado: Listo
        private void ExitButton_MouseEnter(object sender, EventArgs e) {
            closeButtonPanel.BackColor = Color.FromArgb(100, 100, 100);
        }

        //Estado: Listo
        private void ExitButton_MouseLeave(object sender, EventArgs e) {
            closeButtonPanel.BackColor = topPane.BackColor;
        }

        //Estado: Listo
        private void RemoveComponents() {
            SAditionalComponents.WaitOne();
            while (!AditionalComponents.IsEmpty()) {
                Control c = AditionalComponents.Remove(0);
                this.ViewPanel.Controls.Remove(c);
                this.descriptionPanel.Controls.Remove(c);
                this.InfoPanel.Controls.Remove(c);
                this.actionPanel.Controls.Remove(c);
            }
            SAditionalComponents.Release();
            RemoveMessages();
        }

        //Estado: Pendiente
        private void Home_Click(object sender, EventArgs e) {
            RemoveComponents();
            RemoveActiveChats();
            currentView = CurrentView.InHome;
        }

        //Estado: Listo
        private void Chats_Click(object sender, EventArgs e) {
            RemoveComponents();
            RemoveActiveChats();
            AddChatSearchElements();
            currentView = CurrentView.ViewChats;
        }

        //Estado: Listo
        private void Groups_Click(object sender, EventArgs e) {
            RemoveComponents();
            RemoveActiveChats();
            AddChatSearchElements();
            currentView = CurrentView.ViewGroups;
        }

        //Estado: Pendiente
        private void Options_Click(object sender, EventArgs e) {
            RemoveComponents();
            RemoveActiveChats();
            currentView = CurrentView.InProfile;
            Profile profile = new Profile();
            profile.ShowDialog();
        }

        private void Settings_Click(object sender, EventArgs e) {
            
        }

        //Estado: Listo
        private void Send_Click(object sender, EventArgs e) {
            string content = "";
            SAditionalComponents.WaitOne();
            Iterator<Control> i = AditionalComponents.Iterator();
            while (i.HasNext()) {
                Control c = i.Next();
                if (c.Name.Equals("chatBox")) {
                    if(c is TextBox tx) {
                        content = tx.Text;
                        tx.Clear();
                        break;
                    }
                }
            }
            SAditionalComponents.Release();
            if (currentView == CurrentView.InChat) {
                ChatMessage ms = new ChatMessage();
                ms.Sender = model.singleton.userName;
                ms.Receiver = model.CurrentChat;
                ms.Content = content;
                model.ToWriteEnqueue(ms);
            } else if (currentView == CurrentView.InGroup) {
                GroupMessage ms = new GroupMessage(model.CurrentGroup, model.singleton.userName, content);
                model.ToWriteEnqueue(ms);
            }
        }

        //Estado: Listo
        private void AddChatSearchElements() {
            Panel NewChatPanel = new Panel();
            Label NewChatLabel = new Label();
            TextBox NewChatTextBox = new TextBox();
            this.InfoPanel.Controls.Add(NewChatPanel);

            NewChatPanel.Location = new Point(0, 0);
            NewChatPanel.Size = new Size(actionPanel.Width, InfoPanel.Height);
            NewChatPanel.BackColor = Color.Transparent;
            NewChatPanel.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Top);
            NewChatPanel.BorderStyle = BorderStyle.FixedSingle;
            NewChatPanel.Controls.Add(NewChatLabel);
            NewChatPanel.Controls.Add(NewChatTextBox);

            NewChatLabel.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NewChatLabel.ForeColor = Color.FromArgb(220, 220, 220);
            NewChatLabel.Location = new Point(5, 5);
            NewChatLabel.Size = new Size(actionPanel.Width - 10, 18);
            NewChatLabel.Text = "Busca o inicia un nuevo chat";

            NewChatTextBox.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left);
            NewChatTextBox.BackColor = Color.FromArgb(64, 64, 64);
            NewChatTextBox.BorderStyle = BorderStyle.FixedSingle;
            NewChatTextBox.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NewChatTextBox.ForeColor = Color.FromArgb(224, 224, 224);
            NewChatTextBox.ImeMode = ImeMode.NoControl;
            NewChatTextBox.Name = "NewChat";
            NewChatTextBox.Size = new Size(NewChatPanel.Width - 10, 20);
            NewChatTextBox.Location = new Point(5, 28);
            NewChatTextBox.TabIndex = 2;
            NewChatTextBox.Multiline = false;
            NewChatTextBox.TabStop = true;
            NewChatTextBox.TextChanged += new EventHandler(SearchChat);
            SAditionalComponents.WaitOne();
            AditionalComponents.Add(NewChatPanel);
            SAditionalComponents.Release();
        }

        private void SearchChat(object sender, EventArgs e) {
            RemoveActiveChats();
            if(sender is TextBox textBox) {
                if (currentView == CurrentView.ViewChats || currentView == CurrentView.InChat)
                    currentView = CurrentView.SearchingChats;
                else
                    currentView = CurrentView.SearchingGroups;

                if (currentView == CurrentView.SearchingChats) {
                    ShippingData.Profile p = new ShippingData.Profile();
                    p.Name = textBox.Text;
                    model.ToWriteEnqueue(new Chat(model.singleton.userName, p));
                } else
                    model.ToWriteEnqueue(new ChatGroup(-1, textBox.Text));
            }
        }

        //Estado: Listo
        private void AddChatBox() {
            bool exist = false;
            SAditionalComponents.WaitOne();
            ChainNode<Control> c = AditionalComponents.GetNode(0);
            while (c != null) {
                if (c.element.Name.Equals("chatBox")) {
                    exist = true;
                    break;
                }
                c = c.next;
            }
            SAditionalComponents.Release();
            if (!exist) {
                TextBox chat = new TextBox();
                PictureBox sendButton = new PictureBox();
                this.ViewPanel.Controls.Add(chat);
                this.ViewPanel.Controls.Add(sendButton);

                chat.Anchor = ((AnchorStyles)(((AnchorStyles.Bottom | AnchorStyles.Left) | AnchorStyles.Right)));
                chat.BackColor = Color.FromArgb(64, 64, 64);
                chat.BorderStyle = BorderStyle.FixedSingle;
                chat.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
                chat.ForeColor = Color.FromArgb(224, 224, 224);
                chat.ImeMode = ImeMode.NoControl;
                chat.Name = "chatBox";
                chat.MinimumSize = new Size(0, 24);
                chat.Size = new Size(ViewPanel.Width - 50, 22);
                chat.Location = new Point(6, ViewPanel.Height - 30);
                chat.TabIndex = 1;
                chat.Multiline = true;
                chat.TabStop = true;
                chat.Visible = true;
                chat.Enabled = true;

                sendButton.BackColor = Color.Transparent;
                sendButton.Image = Properties.Resources.SendIcon;
                sendButton.Cursor = Cursors.Hand;
                sendButton.Anchor = (AnchorStyles)(AnchorStyles.Bottom | AnchorStyles.Right);
                sendButton.Location = new Point(this.ViewPanel.Width - 36, this.ViewPanel.Height - 30);
                sendButton.Name = "SendButton";
                sendButton.TabStop = false;
                sendButton.Size = new Size(22, 22);
                sendButton.SizeMode = PictureBoxSizeMode.StretchImage;
                sendButton.Click += new EventHandler(this.Send_Click);

                SAditionalComponents.WaitOne();
                AditionalComponents.Add(chat);
                AditionalComponents.Add(sendButton);
                SAditionalComponents.Release();
            }
        }

        //Delegado listo
        private void AddChatMessage(UserChat chat) {
            Panel message = new Panel();
            Label user = new Label();
            Label content = new Label();
            Label time = new Label();
            ChatMessage ms;
            if (chat == default)
                return;
            ms = chat.NewMessageDequeue();
            if (ms == default) {
                ms = chat.OldMessagePop();
                if (ms == default)
                    return;
            }
            AddControl(message, ViewPanel);
            AddControl(user, message);
            AddControl(content, message);
            AddControl(time, message);
            //user label
            ControlParameters cp = new ControlParameters();
            cp.autoSize = true;
            cp.anchor = (AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right);
            cp.location = new Point(2, 2);
            cp.size = new Size(ViewPanel.Width - 4, 18);
            cp.text = ms.Sender;
            cp.contentAlignment = ContentAlignment.MiddleLeft;
            cp.font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, (0));
            cp.foreColor = Color.FromArgb(224, 224, 224);
            cp.name = "UserName";
            cp.tabStop = false;
            CopyParameters(user, cp);
            //content label
            cp = new ControlParameters();
            cp.autoSize = true;
            cp.anchor = (AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right) | AnchorStyles.Bottom);
            cp.location = new Point(2, 30);
            cp.size = new Size(ViewPanel.Width - 4, 20);
            cp.text = ms.Content;
            cp.contentAlignment = ContentAlignment.MiddleLeft;
            cp.font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cp.foreColor = Color.FromArgb(200, 200, 200);
            cp.name = "Content";
            cp.tabStop = false;
            CopyParameters(content, cp);
            //time label
            cp = new ControlParameters();
            cp.anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            cp.location = new Point(ViewPanel.Width - time.Width - 3, ViewPanel.Height - 16);
            cp.size = new Size(42, 13);
            cp.text = ms.date.Hour.ToString();
            cp.contentAlignment = ContentAlignment.MiddleRight;
            cp.autoSize = true;
            cp.foreColor = Color.FromArgb(200, 200, 200);
            cp.name = "Time";
            cp.tabStop = false;
            CopyParameters(time, cp);
            //message panel
            cp = new ControlParameters();
            cp.anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right);
            cp.borderStyle = BorderStyle.FixedSingle;
            cp.size = new Size(ViewPanel.Width, time.Height + content.Height + user.Height + 20);
            if (FirstMessage == null) {
                FirstMessage = ms;
               cp.location = new Point(0, 0);
            } else {
                if (ms.date.CompareTo(FirstMessage.date) < 0) {
                    cp.location = new Point(0, OldMessages.Peek().Location.Y - cp.size.Height);
                    OldMessages.Push(message);
                } else {
                    cp.location = new Point(0, RecentMessages.Peek().Location.Y + cp.size.Height);
                    RecentMessages.Push(message);
                }
            }
            cp.name = "Message";
            cp.tabStop = false;
            CopyParameters(message, cp);
        }

        //Delegado listo
        private void AddGroupMessage(Group group) {
            Panel message = new Panel();
            Label user = new Label();
            Label content = new Label();
            Label time = new Label();
            GroupMessage ms = group.NewMessageDequeue();
            if(ms == default) {
                ms = group.OldMessagePop();
                if (ms == default)
                    return;
            }
            AddControl(message, ViewPanel);
            AddControl(user, message);
            AddControl(content, message);
            AddControl(time, message);
            //user label
            ControlParameters cp = new ControlParameters();
            cp.autoSize = true;
            cp.anchor = (AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right);
            cp.font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            cp.foreColor = Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            cp.location = new Point(2, 2);
            cp.name = "UserName";
            cp.size = new Size(ViewPanel.Width - 4, 18);
            cp.tabStop = false;
            cp.text = ms.Sender;
            CopyParameters(user, cp);
            //content label
            cp = new ControlParameters();
            cp.autoSize = true;
            cp.anchor = (AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right) | AnchorStyles.Bottom);
            cp.font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            cp.foreColor = Color.FromArgb(200, 200, 200);
            cp.location = new Point(2, 30);
            cp.name = "Content";
            cp.size = new Size(ViewPanel.Width - 4, 20);
            cp.tabStop = false;
            cp.text = ms.Content;
            CopyParameters(content, cp);
            //time label
            cp = new ControlParameters();
            cp.anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            cp.autoSize = true;
            cp.foreColor = Color.FromArgb(200, 200, 200);
            cp.name = "Time";
            cp.size = new Size(42, 13);
            cp.tabStop = false;
            cp.text = ms.date.Hour.ToString();
            cp.location = new Point(ViewPanel.Width - time.Width - 3, ViewPanel.Height - 16);
            CopyParameters(time, cp);
            //message panel
            cp = new ControlParameters();
            cp.borderStyle = BorderStyle.FixedSingle;
            cp.anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right);
            cp.name = "Message";
            cp.size = new Size(ViewPanel.Width, time.Height + content.Height + user.Height + 20);
            cp.tabStop = false;
            if (FirstMessage == null) {
                FirstMessage = ms;
                cp.location = new Point(0, 0);
            } else {
                if (ms.date.CompareTo(FirstMessage.date) < 0) {
                    cp.location = new Point(0, OldMessages.Peek().Location.Y - cp.size.Height);
                    OldMessages.Push(message);
                } else {
                    cp.location = new Point(0, RecentMessages.Peek().Location.Y + cp.size.Height);
                    RecentMessages.Push(message);
                }
            }
            CopyParameters(message, cp);
        }

        //Delegados listos
        private void RemoveMessages() {
            FirstMessage = null;
            if (currentView == CurrentView.InChat) {
                ChatMessage ms;
                UserChat uc = model.chats.Search(model.CurrentChat);
                while (!RecentMessages.IsEmpty()) {
                    ms = new ChatMessage();
                    Panel p = RecentMessages.Pop();
                    foreach (Control c in p.Controls) {
                        if (c is Label l) {
                            if (l.Name.Equals("UserName")) {
                                ms.Sender = l.Text;
                            } else if (l.Name.Equals("Content")) {
                                ms.Content = l.Text;
                            } else if (l.Name.Equals("Time")) {
                                ms.date = new Date(DateTime.Parse(l.Text));
                            }
                        }
                    }
                    if (ms.Sender.Equals(model.singleton.userName)) {
                        ms.Receiver = uc.profile.Name;
                    } else {
                        ms.Receiver = model.singleton.userName;
                    }
                    uc.OldMessagesPush(ms);
                    DeleteControl(p, ViewPanel);
                }
                while (!OldMessages.IsEmpty()) {
                    Panel p = OldMessages.Pop();
                    DeleteControl(p, ViewPanel);
                }
            } else if (currentView == CurrentView.InGroup) {
                GroupMessage gm;
                Group group = model.groups.Search(model.CurrentGroup);
                while (!RecentMessages.IsEmpty()) {
                    gm = new GroupMessage(group.code);
                    Panel p = RecentMessages.Pop();
                    foreach (Control c in p.Controls) {
                        if (c is Label l) {
                            if (l.Name.Equals("UserName")) {
                                gm.Sender = l.Text;
                            } else if (l.Name.Equals("Content")) {
                                gm.Content = l.Text;
                            } else if (l.Name.Equals("Time")) {

                            }
                        }
                    }
                    group.OldMessagesPush(gm);
                    DeleteControl(p, ViewPanel);
                }
                while (!OldMessages.IsEmpty()) {
                    Panel p = OldMessages.Pop();
                    DeleteControl(p, ViewPanel);
                }
            }
        }

        //Delgado listo
        /// <summary>
        /// Añade un panel con la informacion del chat en el ActionPanel
        /// </summary>
        /// <param name="c">El chat que se va a agregar</param>
        /// Estado: Listo
        private void AddChat(UserChat c, int i) {
            Panel newPanel = new Panel();
            PictureBox photo = new PictureBox();
            Label user = new Label();
            AddControl(newPanel, actionPanel);
            AddControl(photo, newPanel);
            AddControl(user, newPanel);

            //panel
            ControlParameters cp = new ControlParameters();
            cp.size = new Size(actionPanel.Width, 50);
            cp.anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right); ;
            cp.location = new Point(0, newPanel.Height * i);
            cp.borderStyle = BorderStyle.FixedSingle;
            cp.backColor = Color.Transparent;
            cp.name = c.profile.Name;
            cp.tabStop = false;
            CopyParameters(newPanel, cp);
            newPanel.MouseEnter += new EventHandler(Chat_MouseEnter);
            newPanel.MouseLeave += new EventHandler(Chat_MouseLeave);
            newPanel.Click += new EventHandler(Chat_Click);

            //pictureBox
            cp = new ControlParameters();
            cp.size = new Size(40, 40);
            cp.location = new Point(10, 10);
            cp.pictureBoxSizeMode = PictureBoxSizeMode.StretchImage;
            if (c.profile.Image != null) {
                cp.image = Serializer.DeserializeImage(c.profile.Image);
            }
            CopyParameters(photo, cp);

            //label
            cp = new ControlParameters();
            cp.size = new Size(newPanel.Width - 60, 20);
            cp.location = new Point(50, 10);
            cp.anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right);
            cp.text = c.profile.Name;
            cp.contentAlignment = ContentAlignment.MiddleLeft;
            cp.backColor = Color.Transparent;
            cp.foreColor = Color.FromArgb(200, 200, 200);
            cp.font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CopyParameters(user, cp);

            c.visible = true;
            SActiveChats.WaitOne();
            ActiveChats.Add(newPanel);
            SActiveChats.Release();
        }

        //Delegado pendiente
        /// <summary>
        /// Añade un panel con la información del grupo en el ActionPanel
        /// </summary>
        /// <param name="c">La información del grupo que se va a gregar</param>
        /// Estado: Listo
        private void AddGroup(Group c, int i) {
            Panel newPanel = new Panel();
            PictureBox photo = new PictureBox();
            Label group = new Label();
            AddControl(newPanel, actionPanel);
            AddControl(photo, newPanel);
            AddControl(group, newPanel);
 
            newPanel.Size = new Size(actionPanel.Width, 50);
            newPanel.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right);
            newPanel.BackColor = Color.Transparent;
            newPanel.Name = c.code.ToString();
            newPanel.TabStop = false;
            newPanel.MouseEnter += new EventHandler(Chat_MouseEnter);
            newPanel.MouseLeave += new EventHandler(Chat_MouseLeave);
            newPanel.Click += new EventHandler(Group_Click);
            newPanel.Location = new Point(0, newPanel.Height*i);

            //pictureBox
            photo.Size = new Size(40, 40);
            photo.SizeMode = PictureBoxSizeMode.StretchImage;
            //photo.Image = c.photo;
            photo.Location = new Point(10, 10);
            photo.TabStop = false;

            //label
            group.Text = c.name;
            group.Location = new Point(50, 10);
            group.Size = new Size(newPanel.Width - 60, 20);
            group.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right);
            group.BackColor = Color.Transparent;
            group.ForeColor = Color.FromArgb(200, 200, 200);
            group.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            c.visible = true;
            SActiveChats.WaitOne();
            ActiveChats.Add(newPanel);
            SActiveChats.Release();
        }

        //Delegado listo
        private void ManagmentChat() {
            if (!(currentView == CurrentView.InChat || currentView == CurrentView.ViewChats || currentView == CurrentView.SearchingChats)) {
                return;
            } else if (model.chats.IsEmpty()) {
                SActiveChats.WaitOne();
                if (ActiveChats.IsEmpty()) {
                    Panel p = new Panel();
                    Label l = new Label();
                    AddControl(p, actionPanel);
                    ActiveChats.Add(p);

                    ControlParameters cp = new ControlParameters();
                    cp.text = "Aún no tienes ningún chat";
                    cp.size = new Size(actionPanel.Width - 6, 20);
                    cp.anchor = (AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right) | AnchorStyles.Top);
                    cp.font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    cp.foreColor = Color.FromArgb(200, 200, 200);
                    cp.autoSize = false;
                    cp.location = new Point(0, 0);
                    CopyParameters(l, cp);
                    l.TextAlign = ContentAlignment.MiddleCenter;

                    AddControl(l, p);
                    cp = new ControlParameters();
                    cp.location = new Point(3, 3);
                    cp.anchor = (AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right) | AnchorStyles.Top);
                    cp.size = l.Size;
                    cp.name = "EmptyChat";
                    cp.backColor = Color.Transparent;
                    CopyParameters(p, cp);
                    SActiveChats.Release();
                    return;
                } else {
                    SActiveChats.Release();
                }
            } else {
                SActiveChats.WaitOne();
                if (ActiveChats.Size>=2) {
                    Panel p = ActiveChats.Get(0);
                    if (p.Name.Equals("EmptyChat")) {
                        DeleteControl(p, actionPanel);
                        ActiveChats.RemoveElement(p);
                    }

                }
                SActiveChats.Release();
            }
            Iterator<UserChat> i = model.chats.GetAll().Iterator();
            int count = 0;
            while (i.HasNext()) {
                UserChat c = i.Next();
                if (currentView == CurrentView.SearchingChats) {
                    if (c.searched) {
                        if (!c.visible) {
                            AddChat(c, count);
                        }
                        count++;
                    }
                } else {
                    if (!c.searched) {
                        if (!c.visible) {
                            AddChat(c, count);
                        }
                        count++;
                    }
                }
                if (c.profile.Image == null) {
                    UserChat userChat = model.chats.Search(c.profile.Name);
                    if (userChat != default)
                        if (userChat.profile.Image == null)
                            continue;
                    SActiveChats.WaitOne();
                    foreach (Control control in ActiveChats.Get(count).Controls) {
                        if(control is PictureBox picture) {
                            ChangeImage(picture, Serializer.DeserializeImage(userChat.profile.Image));
                        }
                    }
                    SActiveChats.Release();
                }
            }
        }

        //Delegado listo
        private void ManagmentGroup() {
            if (!(currentView == CurrentView.InChat || currentView == CurrentView.ViewChats || currentView == CurrentView.SearchingGroups)) {
                return;
            } else if (model.groups.IsEmpty()) {
                SActiveChats.WaitOne();
                if (ActiveChats.IsEmpty()) {
                    Panel p = new Panel();
                    Label l = new Label();
                    AddControl(l, actionPanel);
                    ActiveChats.Add(p);

                    ControlParameters cp = new ControlParameters();
                    cp.text = "Aún no tienes ningún grupo";
                    cp.size = new Size(actionPanel.Width - 6, 20);
                    cp.contentAlignment = ContentAlignment.MiddleCenter;
                    cp.anchor = (AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right) | AnchorStyles.Top);
                    cp.location = new Point(0, 0);
                    cp.font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    cp.foreColor = Color.FromArgb(200, 200, 200);
                    cp.autoSize = false;
                    CopyParameters(p, cp);

                    AddControl(l, p);
                    cp = new ControlParameters();
                    cp.location = new Point(3, 3);
                    cp.anchor = (AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right) | AnchorStyles.Top);
                    cp.size = l.Size;
                    cp.name = "EmptyChat";
                    cp.backColor = Color.Transparent;
                    CopyParameters(p, cp);
                    SActiveChats.Release();
                    return;
                } else {
                    SActiveChats.Release();
                }
            } else {
                SActiveChats.WaitOne();
                if (!ActiveChats.IsEmpty()) {
                    Panel p = ActiveChats.Get(0);
                    if (p.Name.Equals("EmptyChat")) {
                        DeleteControl(p, actionPanel);
                        ActiveChats.RemoveElement(p);
                    }

                }
                SActiveChats.Release();
            }
            Iterator<Group> i = model.groups.GetAll().Iterator();
            int count = 0;
            while (i.HasNext()) {
                Group c = i.Next();
                if (currentView == CurrentView.SearchingChats) {
                    if (c.searched) {
                        if (!c.visible) {
                            AddGroup(c, count);
                        }
                        count++;
                    }
                } else {
                    if (!c.searched) {
                        if (!c.visible) {
                            AddGroup(c, count);
                        }
                        count++;
                    }
                }
            }
        }

        //Delegado listo
        private void RemoveActiveChats() {
            SActiveChats.WaitOne();
            Iterator<Panel> i = ActiveChats.Iterator();
            while (i.HasNext())
                DeleteControl(i.Next(), actionPanel);
            ActiveChats = new DynamicArray<Panel>();
            SActiveChats.Release();
            if (currentView == CurrentView.InChat || currentView == CurrentView.ViewChats || currentView == CurrentView.SearchingChats) {
                Iterator<UserChat> uc = model.chats.GetAll().Iterator();
                while (uc.HasNext()) {
                    UserChat chat = uc.Next();
                    chat.visible = false;
                    if (chat.searched)
                        model.chats.Remove(chat.profile.Name);
                }
            } else if (currentView == CurrentView.InGroup || currentView == CurrentView.ViewGroups || currentView == CurrentView.SearchingGroups) {
                Iterator<Group> g = model.groups.GetAll().Iterator();
                while (g.HasNext()) {
                    Group group = g.Next();
                    group.visible = false;
                    if (group.searched)
                        model.groups.Remove(group.code);
                }
            }
        }

        private void Chat_Click(object sender, EventArgs e) {
            AddChatBox();
            if (currentView == CurrentView.SearchingChats) {
                RemoveActiveChats();
            }
            currentView = CurrentView.InChat;
            if (sender is Panel s)
                model.CurrentChat = s.Name;
        }

        private void Group_Click(object sender, EventArgs e) {
            AddChatBox();
            if (currentView == CurrentView.SearchingGroups) {
                RemoveActiveChats();
            }
            currentView = CurrentView.InGroup;
            if (sender is Panel sn)
                model.CurrentGroup = int.Parse(sn.Name);
        }

        private void Chat_MouseEnter(object sender, EventArgs e) {
            if (sender is Panel newPanel)
                newPanel.BackColor = Color.FromArgb(100, 100, 100);
        }

        private void Chat_MouseLeave(object sender, EventArgs e) {
            if (sender is Panel newPanel)
                newPanel.BackColor = Color.Transparent;
        }

        //Subproceso encargado de recibir los mensajes dados por el servidor
        //Estado: Pendiente
        private void Receptor_DoWork(object sender, DoWorkEventArgs e) {
            while (subprocess) {
                if (currentView == CurrentView.InChat) {
                    AddChatMessage(model.chats.Search(model.CurrentChat));
                } else if (currentView == CurrentView.InGroup) {
                    AddGroupMessage(model.groups.Search(model.CurrentGroup));
                } else {
                    RemoveMessages();
                }

                if (model.singleton.ProfileHasChanged) {
                    model.ToWriteEnqueue(new ShippingData.Profile(model.singleton.userName, model.singleton.ProfilePicture, model.singleton.Status));
                    model.singleton.ProfileHasChanged = false;
                    ChangeImage(Profile, Serializer.DeserializeImage(model.singleton.ProfilePicture));
                }

                ManagmentChat();
                ManagmentGroup();
                Data data = model.ToReadDequeue();
                if (data == default)
                    continue;
                if (data is ShippingData.Message) {
                    if (data is ChatMessage chatMessage) {
                        Console.WriteLine("Sender: " + chatMessage.Sender);
                        Console.WriteLine("Receiver: " + chatMessage.Receiver);
                        Console.WriteLine("Content: " + chatMessage.Content);
                        ShippingData.Profile user = new ShippingData.Profile();
                        if (model.singleton.userName.Equals(chatMessage.Sender))
                            user.Name = chatMessage.Receiver;
                        else
                            user.Name = chatMessage.Sender;
                        if (model.chats.Search(user.Name) == default) {
                            model.chats.AddElement(user.Name, new UserChat(user));
                            model.ToWriteEnqueue(new Chat(model.singleton.userName, user));
                        }
                        model.chats.Search(user.Name).NewMessagesEnqueue(chatMessage);
                    } else if (data is GroupMessage groupMessage) {
                        Console.WriteLine("Sender: " + groupMessage.Sender);
                        Console.WriteLine("Id group receiver: " + groupMessage.IdGroupReceiver);
                        Console.WriteLine("Content: " + groupMessage.Content);
                        Group receiver = model.groups.Search(groupMessage.IdGroupReceiver);
                        receiver.NewMessagesEnqueue(groupMessage);
                    }
                } else if (data is ChatGroup chatGroup) {
                    Group newGroup = new Group();
                    newGroup.code = chatGroup.idGroup;
                    newGroup.name = chatGroup.name;
                    if (currentView == CurrentView.SearchingGroups)
                        newGroup.searched = true;
                    else
                        newGroup.searched = false;
                    model.groups.AddElement(newGroup.code, newGroup);
                } else if (data is Chat chat) {
                    Console.WriteLine(chat.memberOne + " " + chat.memberTwo.Name);
                    /*UserChat newChat;
                    Console.WriteLine(chat.memberOne + " " + chat.memberTwo.Name);
                    newChat = new UserChat(chat.memberTwo);
                    if (currentView == CurrentView.SearchingChats)
                        newChat.searched = true;
                    else
                        newChat.searched = false;
                    if (model.chats.Search(newChat.profile.Name) == default) {
                        model.chats.AddElement(newChat.profile.Name, newChat);
                    } else {
                        model.chats.Remove(newChat.profile.Name);
                        model.chats.AddElement(newChat.profile.Name, newChat);
                    }*/
                } else if (data is RequestAnswer requestAnswer) {

                } else if (data is RequestError requestError) {

                } else if (data is ShippingData.Profile p) {
                    Singleton.GetSingleton().ProfilePicture = p.Image;
                    Singleton.GetSingleton().Status = p.Status;
                    ChangeImage(Profile, Serializer.DeserializeImage(model.singleton.ProfilePicture));
                }
            }
        }


        //Delegados
        private void AddControl(Control toAdd, Control In) {
            if (In.InvokeRequired) {
                var d = new AddIn(AddControl);
                In.Invoke(d, new object[] {toAdd, In});
            } else {
                AddControl2(toAdd, In);
            }
        }

        private void AddControl2(Control toAdd, Control In) {
            if (toAdd.InvokeRequired) {
                var d = new AddIn2(AddControl2);
                toAdd.Invoke(d, new object[] { toAdd, In });
            } else {
                In.Controls.Add(toAdd);
            }
        }

        private void DeleteControl(Control toDelete, Control In) {
            if (In.InvokeRequired) {
                var d = new DeleteIn(DeleteControl);
                In.Invoke(d, new object[] { toDelete, In });
            } else {
                In.Controls.Remove(toDelete);
            }
        }

        private void CopyParameters(Control inWhichIWillCopy, ControlParameters theOther) {
            if (inWhichIWillCopy.InvokeRequired) {
                var d = new CopyParametersOf(this.CopyParameters);
                inWhichIWillCopy.Invoke(d, inWhichIWillCopy, theOther);
            } else {
                inWhichIWillCopy.TabStop = theOther.tabStop;
                inWhichIWillCopy.Size = theOther.size;
                inWhichIWillCopy.Anchor = theOther.anchor;
                inWhichIWillCopy.Location = theOther.location;
                inWhichIWillCopy.Name = theOther.name;
                if (inWhichIWillCopy is Panel panel) {
                    panel.AutoSize = theOther.autoSize;
                    panel.BorderStyle = theOther.borderStyle;
                    panel.ForeColor = theOther.foreColor;
                    panel.BackColor = theOther.backColor;
                    panel.Font = theOther.font;
                } else if (inWhichIWillCopy is PictureBox pictureBox) {
                    pictureBox.Image = theOther.image;
                    pictureBox.SizeMode = theOther.pictureBoxSizeMode;
                } else if (inWhichIWillCopy is Label label) {
                    label.AutoSize = theOther.autoSize;
                    label.Text = theOther.text;
                    //label.TextAlign = theOther.contentAlignment;
                    label.ForeColor = theOther.foreColor;
                    label.BackColor = theOther.backColor;
                    label.Font = theOther.font;
                }
            }
        }

        private void ChangeImage(PictureBox pictureBox, Image image) {
            if (pictureBox.InvokeRequired) {
                var d = new ChangeImageOf(this.ChangeImage);
                pictureBox.Invoke(d, pictureBox, image);
            } else {
                pictureBox.Image = image;
            }
        }

        private void TreeButton_Click(object sender, EventArgs e) {
            new TreeView().ShowDialog();
        }
    }
}