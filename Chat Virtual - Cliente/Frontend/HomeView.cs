using Chat_Virtual___Cliente.Backend;
using Chat_Virtual___Cliente.Communication;
using DataStructures;
using ShippingData;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

struct ControlParameters {
    //General
    public bool TabStop;
    public string Name;
    public Size Size;
    public Size MaxSize;
    public AnchorStyles Anchor;
    public Point Location;
    //Para panel
    public BorderStyle BorderStyle;
    //Para picture box
    public Image Image;
    public PictureBoxSizeMode PictureBoxSizeMode;
    //Para label
    public bool AutoEllipsis;
    public string Text;
    public ContentAlignment ContentAlignment;
    //Para panel y label
    public bool AutoSize;
    public Font Font;
    public Color ForeColor;
    public Color BackColor;
    //Para boton
    public Color ButtonBorderColor;
    public int ButtonBorderSize;
    public FlatStyle FlatStyle;
    public Cursor Cursor;
    //Para textBox
    public bool Multiline;
};

enum CurrentView {
    InChat, ViewChats, SearchingChats, InGroup, ViewGroups, SearchingGroups, CreatingGroup, InHome, InProfile
};

namespace Chat_Virtual___Cliente.Frontend {
    public partial class HomeView : Form {

        //Control de vista
        private bool maximized;
        private bool subprocess;
        private MainModel model;
        private CurrentView lastView;
        private CurrentView currentView;

        //Chats-Grupos
        private Panel ActiveChat;                           //Panel que muestra la información del chat o grupo que está activo
        private ShippingData.Message FirstMessage;          //Primer mensaje del cual se creó un panel en el grupo o chat
        private Panel OldestMessage;                        //Panel con el mensaje que se está mostrando que tiene la fecha más antigua (Se usa para posicionar si llega otro mensaje más antiguo)
        private LinkedStack<Panel> RecentMessages;          //Paneles con los mensajes que se están mostrando

        //Controles
        private LinkedList<Control> ChatsControls;          //Controles que se muestran cuando los chats o grupos están activos
        private LinkedList<Control> HomeControls;           //Controles que se muestran cuando la vista principal está activa

        //Delgados
        private delegate void AddIn(Control toAdd, Control In);
        private delegate void AddIn2(Control toAdd, Control In);
        private delegate void DeleteIn(Control toAdd, Control In);
        private delegate void DeleteControlsOf(Control control);
        private delegate void CopyParametersOf(Control controlOne, ControlParameters controlTwo);
        private delegate void ChangeImageOf(PictureBox pb, Image image);
        private delegate void ChangeVisibilityState(Control control, bool Visible);
        private delegate void ChangeSizeOf(Control control, Size size);
        private delegate void ChangeLocationOf(Control control, Point point);
        private delegate void DisposeAControl(Control control);
        private delegate void ChangeScrollPosition(Panel scrollBar, int position);
        private delegate void ChangeTextOf(Control control, string Text);
        private delegate void ChangeContentAlignmentOf(Label control, ContentAlignment contentAlignment);
        private delegate void UserInGroup(SelectUserInGroupPanel Panel, ShippingData.Profile profile, int i);

        //Semaforos
        private Semaphore SGraficControl;

        public HomeView() {
            InitializeComponent();
            model = new MainModel();
            maximized = false;
            subprocess = true;
            ChatsControls = new LinkedList<Control>();
            HomeControls = new LinkedList<Control>();
            RecentMessages = new LinkedStack<Panel>();
            SGraficControl = new Semaphore(1, 1);
            FirstMessage = null;
            this.currentView = this.lastView = CurrentView.InHome;
            Thread graficControl = new Thread(GraficControl);
            graficControl.Start();

            receptor.RunWorkerAsync();
        }

        //Main events

        private void MinButton_Click(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
        }

        private void MinButton_MouseEnter(object sender, EventArgs e) {
            minButtonPanel.BackColor = Color.FromArgb(100, 100, 100);
        }

        private void MinButton_MouseLeave(object sender, EventArgs e) {
            minButtonPanel.BackColor = topPane.BackColor;
        }

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

        private void ResizeButton_MouseEnter(object sender, EventArgs e) {
            resizeButtonPanel.BackColor = Color.FromArgb(100, 100, 100);
        }

        private void ResizeButton_MouseLeave(object sender, EventArgs e) {
            resizeButtonPanel.BackColor = topPane.BackColor;
        }

        private void ExitButton_Click(object sender, EventArgs e) {
            model.Disconnect();
            subprocess = false;
            SGraficControl.WaitOne();
            Application.Exit();
            SGraficControl.Release();
        }

        private void ExitButton_MouseEnter(object sender, EventArgs e) {
            closeButtonPanel.BackColor = Color.FromArgb(100, 100, 100);
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e) {
            closeButtonPanel.BackColor = topPane.BackColor;
        }

        private void Home_Click(object sender, EventArgs e) {
            SGraficControl.WaitOne();
            currentView = CurrentView.InHome;
            SGraficControl.Release();
        }

        private void Chats_Click(object sender, EventArgs e) {
            SGraficControl.WaitOne();
            currentView = CurrentView.ViewChats;
            SGraficControl.Release();
        }

        private void Groups_Click(object sender, EventArgs e) {
            SGraficControl.WaitOne();
            currentView = CurrentView.ViewGroups;
            SGraficControl.Release();
        }

        private void Options_Click(object sender, EventArgs e) {
            SGraficControl.WaitOne();
            currentView = CurrentView.InProfile;
            SGraficControl.Release();
            Profile profile = new Profile(model);
            profile.ShowDialog();
        }

        private void Settings_Click(object sender, EventArgs e) {

        } //Pendiente

        private void TreeButton_Click(object sender, EventArgs e) {
            new TreeView(model).ShowDialog();
        }

        //Remove controls
        private void RemoveHomeElements() {

        }  //Pendiente

        private void RemoveChatsElements() {
            Iterator<Control> controls = ChatsControls.Iterator();
            while (controls.HasNext()) {
                Control control = controls.Next();
                DeleteControl(control, InfoPanel);
                DeleteControl(control, actionPanel);
            }
            ChatsControls = new LinkedList<Control>();
            ChangeVisible(InfoPanel, false);
            ChangeVisible(actionPanel, false);
            RemoveChatBox();
            RemoveActiveChatPanel();
            RemoveActiveChats();
        }

        private void RemoveChatBox() {
            if (ChatBoxPanel.Visible) {
                ChangeVisible(ChatBoxPanel, false);
                ChangeSize(ViewPanel, new Size(ViewPanel.Width, ViewPanel.Height + ChatBoxPanel.Height));
            }
        }

        private void ClearViewPanel() {
            DeleteControls(ViewPanel);
            if (FirstMessage == null)
                return;
            FirstMessage = null;
            OldestMessage = null;
            if (lastView == CurrentView.InChat || lastView == CurrentView.ViewChats) {
                ChatMessage ms;
                UserChat uc = model.SearchChat(RecentMessages.Peek().Name);
                int count = 0;
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
                                ms.date.StringToDate(l.Text);
                            }
                        } else if (c is PictureBox image) {
                            ms.Image = Serializer.SerializeImage(image.Image);
                        }
                    }
                    if (ms.Sender.Equals(model.singleton.userName)) {
                        ms.Receiver = uc.Name;
                    } else {
                        ms.Receiver = model.singleton.userName;
                    }
                    if (count < 20)
                        uc.OldMessagesPush(ms);
                    count++;
                }
            } else if (lastView == CurrentView.InGroup || lastView == CurrentView.ViewGroups) {
                GroupMessage gm;
                Group group = model.SearchGroup(int.Parse(RecentMessages.Peek().Name));
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
                }
            }
        }

        private void RemoveActiveChats() {
            DeleteControls(actionPanel);
            model.SearchedChats = new LinkedList<UserChat>();
            model.SearchedGroups = new LinkedList<Group>();

            if (lastView == CurrentView.InChat || lastView == CurrentView.ViewChats || lastView == CurrentView.SearchingChats) {
                Iterator<UserChat> uc = model.Chats.Iterator();
                while (uc.HasNext()) {
                    UserChat chat = uc.Next();
                    chat.Visible = false;
                    chat.Panel = null;
                }
            } else if (lastView == CurrentView.InGroup || lastView == CurrentView.ViewGroups || lastView == CurrentView.SearchingGroups) {
                Iterator<Group> g = model.Groups.Iterator();
                while (g.HasNext()) {
                    Group group = g.Next();
                    group.Visible = false;
                    group.Panel = null;
                }
            }
        }

        private void RemoveActiveChatPanel() {
            if (ActiveChat != null) {
                DeleteControl(ActiveChat, InfoPanel);
                DisposeControl(ActiveChat);
                ActiveChat = null;
            }
        }

        //Events
        private void Send_Click(object sender, EventArgs e) {
            string content = chat.Text.Trim();
            ClearSearchTextBox();
            if (content.Length == 0)
                return;
            if (currentView == CurrentView.InChat) {
                ChatMessage ms = new ChatMessage();
                ms.Sender = model.singleton.userName;
                ms.Receiver = model.CurrentChat.Name;
                ms.Content = content;
                model.ToWriteEnqueue(ms);
            } else if (currentView == CurrentView.InGroup) {
                GroupMessage ms = new GroupMessage((model.CurrentChat as Group).code, model.singleton.userName, content);
                model.ToWriteEnqueue(ms);
            }
            chat.Text = "";
        }

        private void SendImage_Click(object sender, EventArgs e) {
            SendImage sendImage = new SendImage();
            sendImage.ShowDialog();
            if (sendImage.ImageSelected != null) {
                if (currentView == CurrentView.InChat) {
                    ChatMessage chatMessage = new ChatMessage(model.singleton.userName, model.CurrentChat.Name, sendImage.Coment.Trim());
                    chatMessage.Image = sendImage.ImageSelected;
                    model.ToWriteEnqueue(chatMessage);
                } else {
                    GroupMessage groupMessage = new GroupMessage((model.CurrentChat as Group).code, model.singleton.userName, sendImage.Coment);
                    groupMessage.Image = sendImage.ImageSelected;
                    model.ToWriteEnqueue(groupMessage);
                }
            }
        }

        private void SearchChat(object sender, EventArgs e) {
            TextBox textBox = sender as TextBox;
            if (textBox.Text.Length == 0) {
                if (currentView == CurrentView.SearchingChats)
                    currentView = CurrentView.ViewChats;
                else if (currentView == CurrentView.SearchingGroups)
                    currentView = CurrentView.ViewGroups;
            } else {
                SGraficControl.WaitOne();
                if (currentView == CurrentView.ViewChats || currentView == CurrentView.InChat) {
                    currentView = CurrentView.SearchingChats;
                } else if (currentView == CurrentView.ViewGroups || currentView == CurrentView.InGroup) {
                    currentView = CurrentView.SearchingGroups;
                }
                lastView = currentView;

                if (currentView == CurrentView.SearchingChats) {
                    model.ToWriteEnqueue(new Search(ToSearch.Chat, textBox.Text));
                } else {
                    model.ToWriteEnqueue(new Search(ToSearch.Group, textBox.Text));
                }
                SGraficControl.Release();
            }
        }

        private void Chat_Click(object sender, EventArgs e) {
            if (sender is Panel s) {
                string currentChat = s.Name;
                if (model.CurrentChat == null || !currentChat.Equals(model.CurrentChat.Name) || lastView != CurrentView.InChat) {
                    SGraficControl.WaitOne();
                    if (currentView == CurrentView.SearchingChats)
                        model.Chats.AddFirst(model.SearchSearchedChat(currentChat));
                    model.CurrentChat = model.SearchChat(currentChat);
                    currentView = CurrentView.InChat;
                    AddActiveChatPanel(model.CurrentChat);
                    SGraficControl.Release();
                }
            } else if (sender is Control c) {
                Chat_Click(c.Parent, e);
            }
        }

        private void Group_Click(object sender, EventArgs e) {
            if (sender is Panel sn) {
                int currentGroup = int.Parse(sn.Name);
                if (model.CurrentChat == null || (!(model.CurrentChat is Group group) || group.code != currentGroup) || lastView != CurrentView.InChat) {
                    SGraficControl.WaitOne();
                    if (currentView == CurrentView.SearchingChats)
                        model.Groups.AddFirst(model.SearchSearchedGroup(currentGroup));
                    model.CurrentChat = model.SearchGroup(currentGroup);
                    currentView = CurrentView.InGroup;
                    group = model.SearchGroup(currentGroup);
                    AddActiveChatPanel(group);
                    SGraficControl.Release();
                }
            } else if (sender is Control c) {
                Group_Click(c.Parent, e);
            }
        }

        private void Chat_MouseEnter(object sender, EventArgs e) {
            if (sender is Panel newPanel)
                newPanel.BackColor = Color.FromArgb(100, 100, 100);
            else if (sender is Control s)
                Chat_MouseEnter(s.Parent, e);
        }

        private void Chat_MouseLeave(object sender, EventArgs e) {
            if (sender is Panel newPanel)
                newPanel.BackColor = Color.Transparent;
            else if (sender is Control s)
                Chat_MouseLeave(s.Parent, e);
        }

        private void ChatBoxEnter(object sender, KeyEventArgs e) {
            if (e.Shift && e.KeyCode == Keys.Enter) {
                TextBox textBox = sender as TextBox;
                textBox.AppendText("\n");
            } else if (e.KeyCode == Keys.Enter) {
                Send_Click(sender, new EventArgs());
            }
        }

        private void ChatBoxTextChanged(object sender, EventArgs e) {
            TextBox txtBody = sender as TextBox;
            if (txtBody.Text == "\r\n") {
                txtBody.Text = "";
            }
            const int padding = 3;
            int numLines = txtBody.GetLineFromCharIndex(txtBody.TextLength) + 1;
            int border = txtBody.Height - txtBody.ClientSize.Height;
            int newHeight = txtBody.Font.Height * numLines + padding + border;
            if (newHeight < 100) {
                txtBody.Height = txtBody.Font.Height * numLines + padding + border;
            }
        }

        private void CreateGroup(object sender, EventArgs e) {
            SGraficControl.WaitOne();
            currentView = CurrentView.CreatingGroup;
            SGraficControl.Release();
        }

        private void Select_GroupPhoto(object sender, EventArgs e) {
            try {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    (sender as PictureBox).ImageLocation = dialog.FileName;
                }

            } catch (Exception) {
                MessageBox.Show("SASA", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateGroupClick(object sender, EventArgs e) {
            CreateGroup newGroup = new CreateGroup();
            Button button = sender as Button;
            LinkedList<string> usersToAdd = new LinkedList<string>();
            usersToAdd.Add(model.singleton.userName);
            foreach (Control c in button.Parent.Controls) {
                if (c.Name.Equals("GroupName")) {
                    newGroup.Name = c.Text;
                } else if (c.Name.Equals("GroupDescription")) {
                    newGroup.Description = c.Text;
                } else if(c is SelectUserInGroupPanel users) {
                    if (users.Selected)
                        usersToAdd.Add(users.Name);
                } else if (c is PictureBox Photo) {
                    newGroup.Photo = Serializer.SerializeImage(Photo.Image);
                }
            }
            if (usersToAdd.Size == 1) {

            } else {
                newGroup.Members = usersToAdd.ToArray();
                model.ToWriteEnqueue(newGroup);
                CancelCreateGroupClick(sender, e);
            }
        }

        private void CancelCreateGroupClick(object sender, EventArgs e) {
            SGraficControl.WaitOne();
            currentView = CurrentView.ViewGroups;
            SGraficControl.Release();
        }

        //Add controls
        private void AddHomeElements() {

        }  //Pendiente

        private void AddChatSearchElements(string LabelText) {
            bool Exist = false;
            Label text = new Label();
            Iterator<Control> controls = ChatsControls.Iterator();
            while (controls.HasNext()) {
                Control control = controls.Next();
                if (control.Name.Equals("Search")) {
                    Exist = true;
                    foreach (Control control1 in control.Controls) {
                        if (control1 is Label l) {
                            text = l;
                        }
                    }
                    break;
                }
            }
            if (!Exist) {
                ControlParameters cp = new ControlParameters();
                Panel NewChatPanel = new Panel();
                Label NewChatLabel = new Label();
                TextBox NewChatTextBox = new TextBox();
                AddControl(NewChatPanel, InfoPanel);

                cp.Location = new Point(0, 0);
                cp.Size = new Size(actionPanel.Width, InfoPanel.Height);
                cp.BackColor = Color.Transparent;
                cp.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Top);
                cp.BorderStyle = BorderStyle.FixedSingle;
                cp.Name = "Search";
                AddControl(NewChatLabel, NewChatPanel);
                AddControl(NewChatTextBox, NewChatPanel);
                CopyParameters(NewChatPanel, cp);

                cp = new ControlParameters();
                cp.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
                cp.ForeColor = Color.FromArgb(220, 220, 220);
                cp.Location = new Point(5, 5);
                cp.Size = new Size(actionPanel.Width - 10, 18);
                cp.Text = LabelText;
                CopyParameters(NewChatLabel, cp);

                cp = new ControlParameters();
                cp.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left);
                cp.BackColor = Color.FromArgb(64, 64, 64);
                cp.BorderStyle = BorderStyle.FixedSingle;
                cp.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
                cp.ForeColor = Color.FromArgb(224, 224, 224);
                cp.Name = "NewChat";
                cp.Size = new Size(NewChatPanel.Width - 20, 20);
                cp.Location = new Point(10, 28);
                cp.TabStop = true;
                NewChatTextBox.TextChanged += new EventHandler(SearchChat);
                CopyParameters(NewChatTextBox, cp);

                ChatsControls.Add(NewChatPanel);
            } else {
                ControlParameters cp = new ControlParameters();
                cp.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
                cp.ForeColor = Color.FromArgb(220, 220, 220);
                cp.Location = new Point(5, 5);
                cp.Size = new Size(actionPanel.Width - 10, 18);
                cp.Text = LabelText;
                CopyParameters(text, cp);
            }
        }

        private void AddChatBox() {
            if (!ChatBoxPanel.Visible) {
                ChangeVisible(ChatBoxPanel, true);
                ChangeSize(ViewPanel, new Size(ViewPanel.Width, ViewPanel.Height - ChatBoxPanel.Height));
            }
        }

        private void AddChatMessage(ChatBase chat) {
            Panel message = new Panel();
            Panel line = new Panel();
            Label user = new Label();
            Label content = new Label();
            Label time = new Label();
            PictureBox image = new PictureBox();
            ShippingData.Message ms;
            if (chat == default) {
                return;
            } else if (chat is UserChat userChat) {
                ms = userChat.OldMessagePop();
                if (ms == default) {
                    ms = userChat.NewMessageDequeue();
                    if (ms == default)
                        return;
                }
            } else if (chat is Group group) {
                ms = group.OldMessagePop();
                if(ms == default) {
                    ms = group.NewMessageDequeue();
                    if (ms == default)
                        return;
                }
            } else {
                return;
            }
            AddControl(message, ViewPanel);
            AddControl(line, message);
            AddControl(user, message);
            AddControl(content, message);
            AddControl(time, message);

            //user label
            ControlParameters cp = new ControlParameters();
            cp.AutoSize = true;
            cp.Anchor = (AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right);
            cp.Location = new Point(2, 7);
            cp.Size = new Size(ViewPanel.Width - 4, 18);
            cp.Text = ms.Sender;
            cp.ContentAlignment = ContentAlignment.MiddleLeft;
            cp.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point, (0));
            cp.ForeColor = Color.FromArgb(234, 234, 234);
            cp.Name = "UserName";
            cp.TabStop = false;
            CopyParameters(user, cp);

            //content label
            cp = new ControlParameters();
            if (ms.Content.Length == 0) {
                cp.AutoSize = false;
                cp.Size = new Size(0, 0);
            } else {
                cp.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
                cp.AutoSize = true;
                cp.Size = new Size(ViewPanel.Width - 10, 10);
                cp.MaxSize = new Size(ViewPanel.Width - 4, 0);
                cp.Text = ms.Content;
                cp.ContentAlignment = ContentAlignment.MiddleLeft;
                cp.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
                cp.ForeColor = Color.FromArgb(200, 200, 200);
            }
            cp.Location = new Point(2, 33);
            cp.Name = "Content";
            cp.TabStop = false;
            CopyParameters(content, cp);

            //image pictureBox
            cp = new ControlParameters();
            cp.AutoSize = false;
            cp.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left);
            cp.TabStop = false;
            if (ms.Image != null) {
                AddControl(image, message);
                cp.Size = new Size(ViewPanel.Width - 100, ViewPanel.Width / 2);
                cp.Location = new Point(10, content.Location.Y + content.Height + 5);
                cp.PictureBoxSizeMode = PictureBoxSizeMode.AutoSize;
                cp.Image = Serializer.DeserializeImage(ms.Image);
            } else {
                cp.Size = new Size(0, 0);
            }
            CopyParameters(image, cp);

            //time label
            cp = new ControlParameters();
            cp.AutoSize = true;
            cp.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            cp.Size = new Size(100, 18);
            cp.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cp.Text = ms.date.FormatHourAndMinute(false);
            cp.ContentAlignment = ContentAlignment.MiddleRight;
            cp.Location = new Point(actionPanel.Width - 110, content.Location.Y + 18 + 30);
            cp.ForeColor = Color.FromArgb(150, 150, 150);
            cp.Name = "Time";
            cp.TabStop = false;
            CopyParameters(time, cp);

            //message panel
            cp = new ControlParameters();
            cp.AutoSize = false;
            cp.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            cp.BorderStyle = BorderStyle.None;
            cp.Size = new Size(ViewPanel.Width, time.Height + content.Height + user.Height + 27 + image.Height);
            if (FirstMessage == null) {
                FirstMessage = ms;
                cp.Location = new Point(0, 0);
                OldestMessage = message;
                RecentMessages.Push(message);
            } else {
                if (ms.date.CompareTo(FirstMessage.date) < 0) {
                    cp.Location = new Point(0, OldestMessage.Location.Y - cp.Size.Height);
                    OldestMessage = message;
                } else {
                    cp.Location = new Point(0, RecentMessages.Peek().Location.Y + RecentMessages.Peek().Height);
                    RecentMessages.Push(message);
                }
            }
            if(chat is Group group1)
                cp.Name = group1.code.ToString();
            else
                cp.Name = chat.Name;
            cp.TabStop = false;
            CopyParameters(message, cp);

            cp = new ControlParameters();
            cp.AutoSize = false;
            cp.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom); ;
            cp.BorderStyle = BorderStyle.None;
            cp.Size = new Size(message.Width - 20, 1);
            cp.BackColor = Color.FromArgb(70, 70, 70);
            cp.TabStop = false;
            cp.Location = new Point(10, message.Height - 1);
            CopyParameters(line, cp);

            ChangeScrollBarPosition(ViewPanel, ViewPanel.VerticalScroll.Maximum);
        }

        private void AddChat(ChatBase chatBase, int i) {
            Panel newPanel = new Panel();
            Panel line = new Panel();
            CircularPictureBox photo = new CircularPictureBox();
            Label user = new Label();
            Label lastMessage = new Label();
            AddControl(newPanel, actionPanel);
            AddControl(photo, newPanel);
            AddControl(user, newPanel);
            AddControl(lastMessage, newPanel);
            AddControl(line, newPanel);

            //panel
            ControlParameters cp = new ControlParameters();
            cp.Size = new Size(actionPanel.Width, 50);
            cp.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top); ;
            cp.Location = new Point(0, cp.Size.Height * i);
            cp.BorderStyle = BorderStyle.None;
            cp.BackColor = Color.Transparent;
            if (chatBase is Group group) {
                user.Click += new EventHandler(Group_Click);
                photo.Click += new EventHandler(Group_Click);
                lastMessage.Click += new EventHandler(Group_Click);
                newPanel.Click += new EventHandler(Group_Click);
                cp.Name = group.code.ToString();
            } else {
                user.Click += new EventHandler(Chat_Click);
                photo.Click += new EventHandler(Chat_Click);
                lastMessage.Click += new EventHandler(Chat_Click);
                newPanel.Click += new EventHandler(Chat_Click);
                cp.Name = chatBase.Name;
            }
            cp.TabStop = false;
            CopyParameters(newPanel, cp);
            newPanel.MouseEnter += new EventHandler(Chat_MouseEnter);
            newPanel.MouseLeave += new EventHandler(Chat_MouseLeave);
            chatBase.Panel = newPanel;

            //pictureBox
            cp = new ControlParameters();
            cp.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            cp.Size = new Size(40, 40);
            cp.Location = new Point(5, 5);
            cp.PictureBoxSizeMode = PictureBoxSizeMode.StretchImage;
            if (chatBase.Photo == null) {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(HomeView));
                if(chatBase is Group)
                    chatBase.Photo = Serializer.SerializeImage((Image)(resources.GetObject("Group")));
                else
                    chatBase.Photo = Serializer.SerializeImage((Image)(resources.GetObject("Perfil")));
            }
            cp.Image = Serializer.DeserializeImage(chatBase.Photo);
            cp.Name = "Photo";
            CopyParameters(photo, cp);
            photo.MouseEnter += new EventHandler(Chat_MouseEnter);
            photo.MouseLeave += new EventHandler(Chat_MouseLeave);

            //label user
            cp = new ControlParameters();
            cp.AutoSize = false;
            cp.Name = "User";
            cp.Size = new Size(newPanel.Width - 60, 20);
            cp.Location = new Point(50, 6);
            cp.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right);
            cp.Text = chatBase.Name;
            cp.ContentAlignment = ContentAlignment.MiddleLeft;
            cp.BackColor = Color.Transparent;
            cp.ForeColor = Color.FromArgb(200, 200, 200);
            cp.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CopyParameters(user, cp);
            user.MouseEnter += new EventHandler(Chat_MouseEnter);
            user.MouseLeave += new EventHandler(Chat_MouseLeave);

            //lastMessage
            cp = new ControlParameters();
            cp.AutoSize = false;
            cp.Size = new Size(newPanel.Width - 60, 20);
            cp.Location = new Point(50, 25);
            cp.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right);
            cp.Text = chatBase.LastMessage.Content;
            cp.ContentAlignment = ContentAlignment.MiddleLeft;
            cp.BackColor = Color.Transparent;
            cp.ForeColor = Color.FromArgb(200, 200, 200);
            cp.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cp.Name = "LastMessage";
            cp.AutoEllipsis = true;
            CopyParameters(lastMessage, cp);
            lastMessage.MouseEnter += new EventHandler(Chat_MouseEnter);
            lastMessage.MouseLeave += new EventHandler(Chat_MouseLeave);

            //line
            cp = new ControlParameters();
            cp.AutoSize = false;
            cp.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom); ;
            cp.BorderStyle = BorderStyle.None;
            cp.Size = new Size(newPanel.Width - 20, 1);
            cp.BackColor = Color.FromArgb(70, 70, 70);
            cp.TabStop = false;
            cp.Location = new Point(10, newPanel.Height - 1);
            cp.Name = "Line";
            CopyParameters(line, cp);

            chatBase.Visible = true;
        }

        private void AddActiveChatPanel(ChatBase ClickChat) {
            Label user = new Label(), status = new Label(); ;
            CircularPictureBox photo = new CircularPictureBox();
            if (ActiveChat == null) {
                ActiveChat = new Panel();
                user.Name = "User";
                status.Name = "Status";
                ActiveChat.Controls.Add(user);
                ActiveChat.Controls.Add(status);
                ActiveChat.Controls.Add(photo);
                InfoPanel.Controls.Add(ActiveChat);

                ActiveChat.Size = new Size(ViewPanel.Width + 1, InfoPanel.Height);
                ActiveChat.Location = new Point(actionPanel.Width - 1, 0);
                ActiveChat.BackColor = user.BackColor = status.BackColor = Color.Transparent;
                ActiveChat.AutoSize = user.AutoSize = status.AutoSize = false;
                ActiveChat.Visible = user.Visible = status.Visible = true;
                ActiveChat.BorderStyle = BorderStyle.None;
                ActiveChat.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
                ActiveChat.Name = ClickChat.Name;

                photo.Location = new Point(10, 10);
                photo.Size = new Size(ActiveChat.Height - 20, ActiveChat.Height - 20);
                photo.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left);
                photo.SizeMode = PictureBoxSizeMode.StretchImage;

                user.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
                status.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
                user.AutoEllipsis = status.AutoEllipsis = true;
                user.ForeColor = status.ForeColor = Color.FromArgb(200, 200, 200);
                user.Size = status.Size = new Size(ViewPanel.Width - photo.Width - 30, 20);
                user.Location = new Point(photo.Width + 20, 10); status.Location = new Point(photo.Width + 20, InfoPanel.Height - 30);
            } else {
                foreach (Control c in ActiveChat.Controls) {
                    if (c is Label label) {
                        if (label.Name.Equals("User"))
                            user = label;
                        else
                            status = label;
                    } else if (c is CircularPictureBox pictureBox) {
                        photo = pictureBox;
                    }
                }
            }
            if(ClickChat.Photo != null)
                ChangeImage(photo, Serializer.DeserializeImage(ClickChat.Photo));
            ChangeText(user, ClickChat.Name);
            if (ClickChat is UserChat userChat)
                ChangeText(status, userChat.Status);
            else if (ClickChat is Group group)
                ChangeText(status, group.Description);
        }

        private void AddCreateGroupControl() {
            Panel newPanel = new Panel();
            Label newLabel = new Label();
            PictureBox button = new PictureBox();
            AddControl(newPanel, actionPanel);
            AddControl(newLabel, newPanel);
            AddControl(button, newPanel);

            ControlParameters cp = new ControlParameters();
            cp.Location = new Point(0, 0);
            cp.Size = new Size(actionPanel.Width, 80);
            cp.BackColor = Color.Transparent;
            cp.AutoSize = false;
            cp.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right);
            cp.Name = "CreateGroup";
            CopyParameters(newPanel, cp);

            cp = new ControlParameters();
            cp.Text = "Crea un grupo nuevo";
            cp.Size = new Size(newPanel.Width, 20);
            ChangeContentAlignment(newLabel, ContentAlignment.MiddleCenter);
            cp.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cp.AutoSize = false;
            cp.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cp.Location = new Point(0, 5);
            cp.ForeColor = Color.FromArgb(220, 220, 220);
            cp.BackColor = Color.Transparent;
            CopyParameters(newLabel, cp);

            ComponentResourceManager resources = new ComponentResourceManager(typeof(HomeView));
            cp = new ControlParameters();
            cp.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cp.Size = new Size(40, 40);
            cp.MaxSize = new Size(40, 40);
            cp.Location = new Point((newPanel.Width - cp.Size.Width) / 2, 35);
            cp.BackColor = Color.Transparent;
            cp.PictureBoxSizeMode = PictureBoxSizeMode.Zoom;
            cp.TabStop = false;
            cp.Image = ((Image)(resources.GetObject("SimboloAgregarGrupo")));
            CopyParameters(button, cp);
            button.Click += new EventHandler(CreateGroup);
            ChatsControls.Add(newPanel);
        }

        private void AddCreateGroupControls() {
            TextBox GroupName = new TextBox(), GroupDescription = new TextBox();
            Label NameLabel = new Label(), DescritionLabel = new Label(), Member = new Label();
            Button Create = new Button(), Cancel = new Button();
            CircularPictureBox Photo = new CircularPictureBox();
            AddControl(GroupName, ViewPanel);
            AddControl(GroupDescription, ViewPanel);
            AddControl(NameLabel, ViewPanel);
            AddControl(DescritionLabel, ViewPanel);
            AddControl(Member, ViewPanel);
            AddControl(Create, ViewPanel);
            AddControl(Cancel, ViewPanel);
            AddControl(Photo, ViewPanel);

            ControlParameters cp = new ControlParameters();
            //Photo pictureBox
            ComponentResourceManager resources = new ComponentResourceManager(typeof(HomeView));
            cp.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            cp.Cursor = Cursors.Hand;
            cp.Image = ((Image)(resources.GetObject("ImageAdd")));
            cp.Location = new Point(ViewPanel.Width/20, 40);
            cp.Name = "SelectPictureBox";
            cp.Size = new Size(ViewPanel.Width * 3 / 20, ViewPanel.Width * 3 / 20);
            cp.PictureBoxSizeMode = PictureBoxSizeMode.Zoom;
            cp.TabStop = false;
            CopyParameters(Photo, cp);
            Photo.Click += new EventHandler(this.Select_GroupPhoto);

            //GroupName label
            cp.AutoEllipsis = true;
            cp.Cursor = Cursors.Default;
            cp.BackColor = Color.Transparent;
            cp.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cp.ForeColor = Color.FromArgb(224, 224, 224);
            cp.Name = "NameLabel";
            cp.BorderStyle = BorderStyle.None;
            cp.TabStop = false;
            cp.AutoSize = true;
            cp.Location = new Point(ViewPanel.Width/ 4, 40);
            cp.Text = "Nombre del grupo:";
            CopyParameters(NameLabel, cp);

            //GroupDescriptionLabel
            cp.Name = "DescriptionLabel";
            cp.Location = new Point(NameLabel.Location.X, 70);
            cp.Text = "Descripción del grupo: ";
            CopyParameters(DescritionLabel, cp);

            //GroupName textBox
            cp.BackColor = Color.FromArgb(60, 60, 64);
            cp.AutoSize = false;
            cp.Name = "GroupName";
            cp.BorderStyle = BorderStyle.FixedSingle;
            cp.TabStop = true;
            cp.Size = new Size(ViewPanel.Width*7/10 - DescritionLabel.Width, NameLabel.Height);
            cp.Location = new Point(DescritionLabel.Width + NameLabel.Location.X, NameLabel.Location.Y);
            CopyParameters(GroupName, cp);

            //Description TextBox
            cp.Name = "GroupDescription";
            cp.Size = new Size(GroupName.Width, NameLabel.Height*4);
            cp.Location = new Point(DescritionLabel.Width + NameLabel.Location.X, DescritionLabel.Location.Y);
            cp.Multiline = true;
            CopyParameters(GroupDescription, cp);

            //Member label
            cp.Name = "Member";
            cp.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            cp.AutoEllipsis = true;
            cp.BackColor = Color.Transparent;
            cp.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cp.ForeColor = Color.FromArgb(224, 224, 224);
            cp.Size = new Size(ViewPanel.Width, 26);
            cp.Location = new Point(0, GroupDescription.Height + GroupDescription.Location.Y + 30);
            cp.Text = "Selecciona a tus nuevos seguidores del mal";
            ChangeContentAlignment(Member, ContentAlignment.MiddleCenter);
            CopyParameters(Member, cp);

            //Create Button
            cp.Cursor = Cursors.Hand;
            cp.Name = "CreateButton";
            cp.BackColor = Color.Teal;
            cp.Font = new Font("Calibri", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cp.ForeColor = Color.FromArgb(224, 224, 244);
            cp.ButtonBorderColor = Color.Teal;
            cp.FlatStyle = FlatStyle.Flat;
            cp.ButtonBorderSize = 2;
            cp.Text = "CREAR";
            cp.Size = new Size(89, 37);
            cp.Location = new Point(GroupDescription.Location.X + GroupDescription.Width - cp.Size.Width, Member.Location.Y + Member.Height + 30);
            CopyParameters(Create, cp);
            Create.Click += new EventHandler(CreateGroupClick);

            //Cancel Button
            cp.Name = "CancelButton";
            cp.BackColor = Color.FromArgb(25, 25, 29);
            cp.Font = new Font("Calibri", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cp.ButtonBorderColor = Color.FromArgb(150, 150, 150);
            cp.Size = new Size(92, 37);
            cp.Text = "CANCELAR";
            cp.Location = new Point(Create.Location.X - cp.Size.Width - 15, Create.Location.Y);
            CopyParameters(Cancel, cp);
            Cancel.Click += new EventHandler(CancelCreateGroupClick);
        }

        //Funciones
        private void OrganizeChats() {
            ArrayMaxHeap<Panel> ActiveChats = new ArrayMaxHeap<Panel>();
            if (currentView == CurrentView.InChat || currentView == CurrentView.ViewChats) {
                Iterator<UserChat> iterator = model.Chats.Iterator();
                while (iterator.HasNext()) {
                    UserChat chat = iterator.Next();
                    if (chat.Panel != null)
                        ActiveChats.Insert((int)chat.LastMessage.date.ToLong(), chat.Panel);
                }
            } else {
                Iterator<Group> iterator = model.Groups.Iterator();
                while (iterator.HasNext()) {
                    Group chat = iterator.Next();
                    if (chat.Panel != null)
                        ActiveChats.Insert((int)chat.LastMessage.date.ToLong(), chat.Panel);
                }
                Iterator<Control> iterator1 = ChatsControls.Iterator();
                while (iterator1.HasNext()) {
                    Control c = iterator1.Next();
                    if(c.Name == "CreateGroup") {
                        ChangeLocation(c, new Point(0, ActiveChats.GetNumberOfElements() * ActiveChats.Peek().Height));
                    }
                }
            }

            int i = 0;
            while (!ActiveChats.IsEmpty()) {
                Panel chat = ActiveChats.ExtractMax();
                ChangeLocation(chat, new Point(0, i * chat.Height));
                i++;
            }
        }

        private void ClearSearchTextBox() {
            Iterator<Control> iterator = ChatsControls.Iterator();
            while (iterator.HasNext()) {
                Control control = iterator.Next();
                if (control.Name.Equals("Search")) {
                    foreach (Control c in control.Controls) {
                        if (c is TextBox textBox) {
                            textBox.Text = "";
                            break;
                        }
                    }
                    break;
                }
            }
        }

        private void RefreshChat(ChatBase chat) {
            if(chat.HasChanged && chat.Photo != null) {
                (chat.Panel.Controls.Find("Photo", false)[0] as PictureBox).Image = Serializer.DeserializeImage(chat.Photo);
                chat.HasChanged = false;
                if (model.CurrentChat == chat) {
                    AddActiveChatPanel(chat);
                }
            }
            Label LastMessage = chat.Panel.Controls.Find("LastMessage", false)[0] as Label;
            if(!LastMessage.Text.Equals(chat.LastMessage.Content))
                ChangeText(LastMessage, chat.LastMessage.Content);
        }

        //Subproceso encargado de agregar y eliminar los componentes gráficos según se requiera
        private void GraficControl() {
            while (subprocess) {
                SGraficControl.WaitOne();
                if (lastView != currentView) {
                    ClearViewPanel();

                    if (lastView == CurrentView.CreatingGroup) {
                        if (model.Groups.Get(0).code < 0)
                            model.Groups.Remove(0);
                    } else if(lastView == CurrentView.SearchingGroups || lastView == CurrentView.SearchingChats) {
                        RemoveActiveChats();
                        model.SearchedChats = new LinkedList<UserChat>();
                        model.SearchedGroups = new LinkedList<Group>();
                    }

                    if (currentView == CurrentView.InChat) {
                        AddChatBox();
                    } else if (currentView == CurrentView.ViewChats) {
                        AddChatSearchElements("Busca o inicia un chat");
                        ChangeVisible(actionPanel, true);
                        ChangeVisible(InfoPanel, true);
                        RemoveActiveChatPanel();
                        if (lastView != CurrentView.InChat) {
                            RemoveActiveChats();
                        }
                    } else if (currentView == CurrentView.SearchingChats || currentView == CurrentView.SearchingGroups) {
                        RemoveActiveChats();
                    } else if (currentView == CurrentView.InGroup) {
                        AddChatBox();
                    } else if (currentView == CurrentView.ViewGroups) {
                        AddChatSearchElements("Busca un grupo");
                        ChangeVisible(actionPanel, true);
                        ChangeVisible(InfoPanel, true);
                        RemoveActiveChatPanel();
                        if (lastView != CurrentView.InGroup) {
                            RemoveActiveChats();
                        }
                        AddCreateGroupControl();
                    } else if (currentView == CurrentView.CreatingGroup) {
                        model.Groups.AddFirst(new Group(-2, "Grupo Nuevo"));
                        model.ToWriteEnqueue(new Search(ToSearch.NewGroup, model.singleton.userName));
                        AddCreateGroupControls();
                    } else { //currentView == CurrentView.InHome
                        RemoveChatsElements();
                        AddHomeElements();
                    }

                    lastView = currentView;
                }
                if (currentView == CurrentView.InChat || currentView == CurrentView.ViewChats) {
                    Iterator<UserChat> iterator = model.Chats.Iterator();
                    int count = 0;
                    bool NeedChange = false;
                    while (iterator.HasNext()) {
                        UserChat chat = iterator.Next();
                        if (!chat.Visible) {
                            AddChat(chat, count);
                            chat.HasChanged = false;
                            NeedChange = true;
                        }
                        count++;
                        RefreshChat(chat);
                    }
                    if (currentView == CurrentView.InChat)
                        AddChatMessage(model.CurrentChat);
                    if (NeedChange)
                        OrganizeChats();
                } else if (currentView == CurrentView.SearchingChats) {
                    Iterator<UserChat> iterator = model.SearchedChats.Iterator();
                    int count = 0;
                    while (iterator.HasNext()) {
                        UserChat chat = iterator.Next();
                        if (!chat.Visible)
                            AddChat(chat, count);
                        count++;
                    }
                } else if (currentView == CurrentView.InGroup || currentView == CurrentView.ViewGroups) {
                    Iterator<Group> iterator = model.Groups.Iterator();
                    int count = 0;
                    bool NeedChange = false;
                    while (iterator.HasNext()) {
                        Group chat = iterator.Next();
                        if (!chat.Visible) {
                            AddChat(chat, count);
                            chat.HasChanged = false;
                            NeedChange = true;
                        }
                        count++;
                        RefreshChat(chat);
                    }
                    if (currentView == CurrentView.InGroup)
                        AddChatMessage(model.CurrentChat);
                    if (NeedChange)
                        OrganizeChats();
                } else if (currentView == CurrentView.SearchingGroups) {
                    Iterator<Group> iterator = model.SearchedGroups.Iterator();
                    int count = 0;
                    while (iterator.HasNext()) {
                        Group chat = iterator.Next();
                        if (!chat.Visible)
                            AddChat(chat, count);
                        count++;
                    }
                } else if (currentView == CurrentView.CreatingGroup) {
                    if(model.Groups.Get(0).code == -3) {
                        Control Create, Cancel, Member, GroupDescription;
                        Create = Cancel = Member = GroupDescription = new Control();
                        foreach (Control c in ViewPanel.Controls) {
                            if (c is SelectUserInGroupPanel user)
                                break;
                            switch (c.Name) {
                                case "CreateButton":
                                    Create = c;
                                    break;
                                case "CanceButton":
                                    Cancel = c;
                                    break;
                                case "GroupDescription":
                                    GroupDescription = c;
                                    break;
                                case "Member":
                                    Member = c;
                                    break;
                            }
                        }
                        Iterator<ShippingData.Profile> iterator = model.Groups.Remove(0).members.Iterator();
                        int count = 0, Displacement = Member.Location.Y + Member.Height + 20;
                        Panel lastPanel = null;
                        while (iterator.HasNext()) {
                            ShippingData.Profile profile = iterator.Next();
                            SelectUserInGroupPanel panel = new SelectUserInGroupPanel(Displacement);
                            AddControl(panel, ViewPanel);
                            CreateUserInGroupSelection(panel, profile, count);
                            lastPanel = panel;
                            count++;
                        }
                        if (lastPanel != null) {
                            ChangeLocation(Create, new Point(GroupDescription.Location.X + GroupDescription.Width - Create.Size.Width, lastPanel.Location.Y + lastPanel.Height + 30));
                            ChangeLocation(Cancel, new Point(Create.Location.X - Cancel.Size.Width - 15, Create.Location.Y));
                        }
                        model.Groups.Remove(0);
                    }
                }
                SGraficControl.Release();
            }
        }

        //Subproceso encargado de recibir los mensajes dados por el servidor
        private void Receptor_DoWork(object sender, DoWorkEventArgs e) {
            //Tester();
            while (subprocess) {
                if (model.singleton.ProfileHasChanged) {
                    model.ToWriteEnqueue(new ShippingData.Profile(model.singleton.userName, model.singleton.ProfilePicture, model.singleton.Status));
                    model.singleton.ProfileHasChanged = false;
                    ChangeImage(Profile, Serializer.DeserializeImage(model.singleton.ProfilePicture));
                }

                if (model.IsConnected()) {
                    model.DataControl();
                } else {
                    model.Connect();
                }

                Data data = model.ToReadDequeue();
                if (data == default)
                    continue;
                if (data is ShippingData.Message) {
                    if (data is ChatMessage chatMessage) {
                        ShippingData.Profile user = new ShippingData.Profile();
                        if (model.singleton.userName.Equals(chatMessage.Sender))
                            user.Name = chatMessage.Receiver;
                        else
                            user.Name = chatMessage.Sender;
                        UserChat SearchedChat = model.SearchChat(user.Name);
                        if (SearchedChat == default) {
                            SearchedChat = new UserChat(user);
                            model.Chats.Add(SearchedChat);
                            model.ToWriteEnqueue(new Chat(model.singleton.userName, user));
                        }
                        SearchedChat.NewMessagesEnqueue(chatMessage);
                        if (SearchedChat.Panel != null)
                            OrganizeChats();
                    } else if (data is GroupMessage groupMessage) {
                        Group Group = model.SearchGroup(groupMessage.IdGroupReceiver);
                        Group.NewMessagesEnqueue(groupMessage);
                    }
                } else if (data is ChatGroup chatGroup) {
                    Group oldGroup = model.SearchGroup(chatGroup.IdGroup);
                    if (oldGroup == default) {
                        model.Groups.Add(new Group(chatGroup));
                    } else {
                        oldGroup.Photo = chatGroup.Photo;
                        oldGroup.Name = chatGroup.Name;
                        oldGroup.HasChanged = true;
                    }
                } else if (data is Chat chat) {
                    UserChat oldChat = model.SearchChat(chat.memberTwo.Name);
                    if (oldChat != default) {
                        oldChat.Photo = chat.memberTwo.Image;
                        oldChat.Status = chat.memberTwo.Status;
                        oldChat.HasChanged = true;
                    } else {
                        model.Chats.Add(new UserChat(chat.memberTwo));
                    }
                } else if (data is RequestAnswer requestAnswer) {

                } else if (data is RequestError requestError) {

                } else if (data is ShippingData.Profile p) {
                    Singleton.GetSingleton().ProfilePicture = p.Image;
                    Singleton.GetSingleton().Status = p.Status;
                    ChangeImage(Profile, Serializer.DeserializeImage(model.singleton.ProfilePicture));
                } else if (data is TreeActivities tree) {
                    Singleton.GetSingleton().tree = tree.Node;
                } else if (data is UserList userList) {
                    if (userList.Users != null) {
                        if (userList.AnswerType == SearchRequest.SearchUsers) {
                            SGraficControl.WaitOne();
                            RemoveActiveChats();
                            model.SearchedChats = new LinkedList<UserChat>();
                            for (int i = 0; i < userList.Users.Length; i++) {
                                model.SearchedChats.Add(new UserChat(userList.Users[i]));
                            }
                            SGraficControl.Release();
                        } else if (userList.AnswerType == SearchRequest.Groupmembers) {

                        } else if (userList.AnswerType == SearchRequest.CreateGroup) {
                            Group group = model.Groups.Get(0);
                            if(group.code == -2) {
                                for(int i = 0; i<userList.Users.Length; i++) {
                                    ShippingData.Profile profile = new ShippingData.Profile();
                                    profile.Name = userList.Users[i].Name;
                                    profile.Image = userList.Users[i].Image;
                                    profile.Status = userList.Users[i].Status;
                                    group.members.Add(profile);
                                }
                                group.code = -3;
                            }
                        }
                    }
                } else if (data is GroupResult groupResult) {
                    SGraficControl.WaitOne();
                    RemoveActiveChats();
                    model.SearchedGroups = new LinkedList<Group>();
                    for (int i = 0; i < groupResult.Groups.Length; i++) {
                        model.SearchedGroups.Add(new Group(groupResult.Groups[i]));
                    }
                    SGraficControl.Release();
                }
            }
            while (!model.toWrite.IsEmpty())
                model.Write();
        }

        //Delegados
        private void AddControl(Control toAdd, Control In) {
            if (In.InvokeRequired) {
                var d = new AddIn(AddControl);
                In.Invoke(d, new object[] { toAdd, In });
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

        private void DeleteControls(Control control) {
            if (control.InvokeRequired) {
                var d = new DeleteControlsOf(DeleteControls);
                control.Invoke(d, control);
            } else {
                control.Controls.Clear();
            }
        }

        private void CopyParameters(Control inWhichIWillCopy, ControlParameters theOther) {
            if (inWhichIWillCopy.InvokeRequired) {
                var d = new CopyParametersOf(this.CopyParameters);
                inWhichIWillCopy.Invoke(d, inWhichIWillCopy, theOther);
            } else {
                inWhichIWillCopy.TabStop = theOther.TabStop;
                inWhichIWillCopy.Size = theOther.Size;
                inWhichIWillCopy.Anchor = theOther.Anchor;
                inWhichIWillCopy.Location = theOther.Location;
                inWhichIWillCopy.Name = theOther.Name;
                inWhichIWillCopy.MaximumSize = theOther.MaxSize;
                if (inWhichIWillCopy is Panel panel) {
                    panel.AutoSize = theOther.AutoSize;
                    panel.BorderStyle = theOther.BorderStyle;
                    panel.ForeColor = theOther.ForeColor;
                    panel.BackColor = theOther.BackColor;
                    panel.Font = theOther.Font;
                } else if (inWhichIWillCopy is PictureBox pictureBox) {
                    pictureBox.Image = theOther.Image;
                    pictureBox.SizeMode = theOther.PictureBoxSizeMode;
                    pictureBox.Cursor = Cursors.Hand;
                } else if (inWhichIWillCopy is Label label) {
                    label.AutoSize = theOther.AutoSize;
                    label.AutoEllipsis = theOther.AutoEllipsis;
                    label.Text = theOther.Text;
                    //label.TextAlign = theOther.contentAlignment;
                    label.ForeColor = theOther.ForeColor;
                    label.BackColor = theOther.BackColor;
                    label.Font = theOther.Font;
                } else if (inWhichIWillCopy is TextBox textBox) {
                    textBox.BackColor = theOther.BackColor;
                    textBox.BorderStyle = theOther.BorderStyle;
                    textBox.ForeColor = theOther.ForeColor;
                    textBox.Multiline = theOther.Multiline;
                } else if(inWhichIWillCopy is Button button) {
                    button.BackColor = theOther.BackColor;
                    button.ForeColor = theOther.ForeColor;
                    button.Text = theOther.Text;
                    button.Font = theOther.Font;
                    button.FlatStyle = theOther.FlatStyle;
                    button.FlatAppearance.BorderColor = theOther.ButtonBorderColor;
                    button.FlatAppearance.BorderSize = theOther.ButtonBorderSize;
                    button.Cursor = theOther.Cursor;
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

        private void ChangeVisible(Control ToChange, bool Visible) {
            if (ToChange.InvokeRequired) {
                var d = new ChangeVisibilityState(this.ChangeVisible);
                ToChange.Invoke(d, ToChange, Visible);
            } else {
                ToChange.Visible = Visible;
            }
        }

        private void ChangeSize(Control ToChange, Size size) {
            if (ToChange.InvokeRequired) {
                var d = new ChangeSizeOf(this.ChangeSize);
                ToChange.Invoke(d, ToChange, size);
            } else {
                ToChange.Size = new Size(size.Width, size.Height);
            }
        }

        private void ChangeLocation(Control ToChange, Point Location) {
            if (ToChange.InvokeRequired) {
                var d = new ChangeLocationOf(ChangeLocation);
                ToChange.Invoke(d, ToChange, Location);
            } else {
                ToChange.Location = Location;
            }
        }

        private void DisposeControl(Control ToDispose) {
            if (ToDispose.InvokeRequired) {
                var d = new DisposeAControl(this.DisposeControl);
                ToDispose.Invoke(d, ToDispose);
            } else {
                ToDispose.Dispose();
            }
        }

        private void ChangeScrollBarPosition(Panel scrollBar, int position) {
            if (scrollBar.InvokeRequired) {
                var d = new ChangeScrollPosition(ChangeScrollBarPosition);
                scrollBar.Invoke(d, scrollBar, position);
            } else {
                scrollBar.VerticalScroll.Value = position;
            }
        }

        private void ChangeText(Control control, string Text) {
            if (control.InvokeRequired) {
                var d = new ChangeTextOf(ChangeText);
                control.Invoke(d, control, Text);
            } else {
                control.Text = Text;
            }
        }

        private void ChangeContentAlignment(Label label, ContentAlignment ContentAlignment) {
            if (label.InvokeRequired) {
                var d = new ChangeContentAlignmentOf(ChangeContentAlignment);
                label.Invoke(d, label, ContentAlignment);
            } else {
                label.TextAlign = ContentAlignment;
            }
        }

        private void CreateUserInGroupSelection(SelectUserInGroupPanel panel, ShippingData.Profile profile, int i) {
            if (panel.InvokeRequired) {
                var d = new UserInGroup(CreateUserInGroupSelection);
                panel.Invoke(d, panel, profile, i);
            } else {
                panel.Create(profile, i);
            }
        }
    }
}