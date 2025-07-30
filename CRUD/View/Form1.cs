using Microsoft.VisualBasic;

namespace CRUD.View;

public partial class Form1 : Form
{
    private readonly TextBox _nomeBox;
    private readonly TextBox _emailBox;
    private readonly TextBox _telefoneBox;
    private readonly Button _addButton;
    private readonly Button _editButton;
    private readonly Button _deleteButton;
    private readonly Button _readButton;
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
            Text = "Telefone:",
            Location = new Point(10, 130),
            Size = new Size(100, 15)
        };

        _telefoneBox = new TextBox
        {
            Location = new Point(10, 170),
            Size = new Size(200, 15)
        };

        _addButton = new Button
        {
            Location = new Point(10, 230),
            Size = new Size(150, 30),
            Text = "Add"
        };
        _addButton.Click += myButton_Click;

        _editButton = new Button
        {
            Location = new Point(10, 300),
            Size = new Size(150, 30),
            Text = "Edit",
        };
        _editButton.Click += myButton2_Click;

        _readButton = new Button
        {
            Location = new Point(200, 230),
            Size = new Size(150, 30),
            Text = "Read"
        };
        _readButton.Click += myButton3_Click;
        
        _deleteButton = new Button
        {
            Location = new Point(200, 300),
            Size = new Size(150, 30),
            Text = "Delete"
        };
        _deleteButton.Click += myButton4_Click;

        Controls.AddRange(new System.Windows.Forms.Control[] {myLabel, _nomeBox, myLabel2, _emailBox, myLabel3, _telefoneBox, _addButton, _editButton, _deleteButton, _readButton});
    }

    private void myButton_Click(object? sender, EventArgs e)
    {
        if (_nomeBox.Text == "" || _emailBox.Text == "" || _telefoneBox.Text == "")
        {
            MessageBox.Show("Nenhum dos campos podem ser nulos");
            return;
        }
        var control = new Control.Control().AdicionarCliente(_nomeBox.Text, _emailBox.Text, _telefoneBox.Text);
        if (control != null)
        {
            MessageBox.Show("Cliente adicionado com sucesso");
            return;
        }
        MessageBox.Show("Error ao adicionar o cliente");
    }

    private void myButton2_Click(object? sender, EventArgs e)
    {
        if (_nomeBox.Text == "" || _emailBox.Text == "" || _telefoneBox.Text == "")
        {
            MessageBox.Show("Nenhum dos campos podem ser nulos");
            return;
        }
        
        var control = new Control.Control().AlterarCliente(int.Parse(Interaction.InputBox("Id do cliente", "ID input")), _nomeBox.Text, _emailBox.Text, _telefoneBox.Text);
        if (control != null)
        {
            MessageBox.Show("Cliente alterado com sucesso");
            return;
        }
        MessageBox.Show("Error ao alterar o cliente");
    }

    private static void myButton3_Click(object? sender, EventArgs e)
    {
        var control = new Control.Control().BuscarCliente(int.Parse(Interaction.InputBox("Id do cliente", "ID input")));
        if (control != null)
        {
            MessageBox.Show(control.ToString());
            return;
        }
        MessageBox.Show("Error ao encontrar o cliente");
    }

    private static void myButton4_Click(object? sender, EventArgs e)
    {
        var control = new Control.Control().RemoverCliente(int.Parse(Interaction.InputBox("Id do cliente", "ID input")));
        if (control != null)
        {
            MessageBox.Show("Cliente deletado com sucesso");
            return;
        }
        MessageBox.Show("Error ao deletar o cliente");
    }
}