Imports System.IO
Imports System.Net
Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        End
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = Nothing Or TextBox2.Text = Nothing Then
            exeption("Veuillez entrer un pseudo et un mot de passe pour vous connecter !")
            Exit Sub
        End If
            WriteParams(TextBox1.Text)
            Login(TextBox1.Text, TextBox2.Text)
            ReadParams()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox1.Text = Nothing Or TextBox2.Text = Nothing Then
            exeption("Veuillez entrer un pseudo et un mot de passe pour créer votre compte !")
            Exit Sub
        End If
        Create_Account(TextBox1.Text, TextBox2.Text)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.MouseEnter
        Label1.BackColor = Color.Red()
    End Sub

    Private Sub Label1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.MouseLeave
        Label1.BackColor = Color.DarkRed
    End Sub
End Class
