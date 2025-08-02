using Microsoft.VisualBasic;

namespace CRUD.View;

public partial class Form1 : Form
{
    private readonly TextBox _nomeBox;
    private readonly TextBox _emailBox;
    private readonly TextBox _senhaBox;
    private readonly TextBox _telefoneBox;
    private readonly Button _addButton;
    private readonly Button _editButton;
    private readonly Button _deleteButton;
    private readonly Button _readButton;
    private readonly Button _loginButton;
    public Form1()
    {
        InitializeComponent();

        var myLabel = new Label
        {
            Text = "Nome:",
            Location = new Point(10, 10),
            Size = new Size(100, 20)
        };
        
        _nomeBox = new TextBox
        {
            Location = new Point(10, 40),
            Size = new Size(200, 15)
        };

        var myLabel2 = new Label
        {
            Text = "Email:",
            Location = new Point(10, 70),
            Size = new Size(100, 15)
        };

        _emailBox = new TextBox
        {
            Location = new Point(10, 100),
            Size = new Size(200, 15)
        };

        var myLabel3 = new Label
        {
            Text = "Senha:",
            Location = new Point(10, 130),
            Size = new Size(100, 15)
        };

        _senhaBox = new TextBox
        {
            Location = new Point(10, 170),
            Size = new Size(200, 15)
        };
        
        var myLabel4 = new Label
        {
            Text = "Telefone:",
            Location = new Point(10, 200),
            Size = new Size(100, 15)
        };

        _telefoneBox = new TextBox
        {
            Location = new Point(10, 230),
            Size = new Size(200, 15)
        };

        _addButton = new Button
        {
            Location = new Point(10, 270),
            Size = new Size(150, 30),
            Text = "Add"
        };
        _addButton.Click += myButton_Click;

        _editButton = new Button
        {
            Location = new Point(10, 330),
            Size = new Size(150, 30),
            Text = "Edit",
        };
        _editButton.Click += myButton2_Click;

        _readButton = new Button
        {
            Location = new Point(200, 270),
            Size = new Size(150, 30),
            Text = "Read"
        };
        _readButton.Click += myButton3_Click;
        
        _deleteButton = new Button
        {
            Location = new Point(200, 330),
            Size = new Size(150, 30),
            Text = "Delete"
        };
        _deleteButton.Click += myButton4_Click;

        _loginButton = new Button
        {
            Location = new Point(390, 270),
            Size = new Size(150, 30),
            Text = "Login"
        };
        _loginButton.Click += myButton5_Click;

        Controls.AddRange(new System.Windows.Forms.Control[] {
            myLabel,
            _nomeBox,
            myLabel2,
            _emailBox,
            myLabel3,
            _senhaBox,
            myLabel4,
            _telefoneBox,
            _addButton,
            _editButton,
            _deleteButton,
            _readButton,
            _loginButton
        });
    }

    private void myButton_Click(object? sender, EventArgs e)
    {
        MessageBox.Show(_nomeBox.Text == "" || _emailBox.Text == "" || _senhaBox.Text == "" || _telefoneBox.Text == "" ?
            "Nenhum dos campos podem ser nulos" :
            new Control.Control().AdicionarCliente(_nomeBox.Text, _emailBox.Text, _senhaBox.Text, _telefoneBox.Text) != null ?
                "Cliente adicionado com sucesso" :
                "Error ao adicionar o cliente");
    }

    private void myButton2_Click(object? sender, EventArgs e)
    {
        var input = Interaction.InputBox("Id do cliente", "ID do cliente");
        if (!int.TryParse(input, out var id))
        {
            MessageBox.Show("O valor digitado não é um digito ou é abaixo de 0");
            return;
        }
        MessageBox.Show(_nomeBox.Text == "" || _emailBox.Text == "" || _senhaBox.Text == "" || _telefoneBox.Text == "" ?
            "Nenhum dos campos podem ser nulos" :
            new Control.Control().AlterarCliente(id, _nomeBox.Text, _emailBox.Text, _senhaBox.Text, _telefoneBox.Text) != null ?
                "Cliente alterado com sucesso" : "Error ao alterar o cliente");
    }

    private static void myButton3_Click(object? sender, EventArgs e)
    {
        var input = Interaction.InputBox("Id do cliente", "ID input");
        if (!int.TryParse(input, out var id) || id <= 0)
        {
            MessageBox.Show("O valor digitado não é um digito ou é abaixo de 0");
            return;
        }
        var cliente = new Control.Control().BuscarCliente(id);
        MessageBox.Show(cliente != null ?
            cliente.ToString() :
            "Error ao encontrar o cliente");
    }

    private static void myButton4_Click(object? sender, EventArgs e)
    {
        var input = Interaction.InputBox("Id do cliente", "ID input");
        if (!int.TryParse(input, out var id) || id <= 0)
        {
            MessageBox.Show("O valor digitado não é um digito ou é abaixo de 0");
            return;
        }
        var cliente = new Control.Control().RemoverCliente(id);
        MessageBox.Show(cliente != null ?
            "Cliente deletado com sucesso" : "Error ao deletar o cliente");
    }

    private void myButton5_Click(object? sender, EventArgs e)
    {
        MessageBox.Show(_emailBox.Text == "" || _senhaBox.Text == "" ?
            "Email ou senha não podem ser nulos" :
            new Control.Control().VerificarLogin(_emailBox.Text, _senhaBox.Text) ?
                "Login realizado com sucesso" : "Email ou senha incorretos");
    }
}