using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace GUIDemo
{
    public class Utils
    {
        /*Implemente o método estático da classe ControlUtils, 
        
        void RegistHandlerInEvents(Control control, Object obj, MethodInfo mi, String pattern), 
        
        o qual regista um novo delegate para o método de
        instância representado por mi em todos os eventos do 
        controlo Windows Forms control cujo nome inclua a string
        pattern. 

        O método de instância é chamado sobre o objecto referido 
        por obj. Assuma que mi representa um método
        compatível com os eventos abrangidos pela string pattern. 
        Considere a existência do método de instância bool
        Contains(String s) da classe String.*/

        public static void RegistHandlerInEvents(
            Control control, 
            Object obj, 
            MethodInfo mi, 
            String pattern)
        {
            foreach(EventInfo ei in control.GetType().GetEvents())
            {
                if (ei.Name.Contains(pattern))
                {
                    Console.WriteLine("Registering new handler for event {0}", ei.Name);
                    Type delType = ei.EventHandlerType;
                    MethodInfo delInfo = delType.GetMethod("Invoke");
                    
                    Delegate newDel =
                        Delegate.CreateDelegate(
                            delType,
                            obj,
                            mi);
                    ei.AddEventHandler(control, newDel);
                }
            }


        }
    }

    public class SingleButton : Form
    {
        private readonly int W = 100, H = 50;
        private Button button;

        public void M(object sender, EventArgs ea)
        {
            Console.WriteLine("@SingleButton.M");
        }

        public SingleButton()
        {
            PrepareGUI();
            Utils.RegistHandlerInEvents(
                button,
                this,
                GetType().GetMethod("M"),
                "Click");
        }

        private void PrepareGUI()
        {
            this.Name = "SingleButtonForm";
            this.Text = "A small GUI demo";
            this.Size = new Size(320, 240);
            this.StartPosition = FormStartPosition.CenterScreen;

            button = new Button();
            button.Name = "Btn_ClickMe";
            button.Text = "Click Me!";
            button.Size = new Size(W, H);
            button.Location = new Point(this.ClientRectangle.Width / 2 - W / 2, ClientRectangle.Height / 2 - H / 2);

            this.Controls.Add(button);

            // Registo de handler no evento Click, para executar Button_OnClick sempre que o botão é pressionado 
            button.Click += new System.EventHandler(this.Button_OnClick);

            // Registo de mais um handler no evento Click, configurando uma acção adicional. 
            button.Click += (o, e) => { Console.WriteLine("Hi from the console"); };

            // Registo de handler para pedir confirmação quando se tenta fechar a janela.
            /*this.FormClosing += (o, e) =>
            {
                DialogResult res = MessageBox.Show("Really close?", "Confirm", MessageBoxButtons.YesNo);
                e.Cancel = res == DialogResult.No;
            };*/
        }

        private void Button_OnClick(object source, EventArgs args)
        {
            MessageBox.Show("Hi from inside a message box!", "I'm a message box");
        }

        public static void Main(String[] args)
        {
            Application.Run(new SingleButton());
        }
    }
}
