Imports System.Net
Imports System.IO
Module AccountAPI
    Public Sub exeption(ByVal text As String)
        MessageBox.Show(text, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    Public Sub Create_Account(ByVal User As String, ByVal Pass As String)
        Dim User1 As String = "" '' utilisateur ftp
        Dim Pass1 As String = "653421mate" '' mot de passe ftp
        Dim Service_Register As String = ("") ''Votre FTP "ftp://utilisateur@hôte/dossier(htdocs ou public html pour les hebergeurs gratuits)/dossier réservé aux comptes"
        Dim accounttempfile As String = (My.Computer.FileSystem.SpecialDirectories.Temp & "\" & User & ".ini")
        Dim tempparam1 As String = (My.Computer.FileSystem.SpecialDirectories.Temp & "\" & User & "_param1.ini")
        Dim tempparam2 As String = (My.Computer.FileSystem.SpecialDirectories.Temp & "\" & User & "_param2.ini")
        Dim sw As New StreamWriter(accounttempfile)
        Dim sw1 As New StreamWriter(tempparam1)
        Dim sw2 As New StreamWriter(tempparam2)
        sw.Write(Pass)
        sw1.Write("Premium=false")
        sw2.Write("Banned=false")
        sw.Close()
        sw1.Close()
        sw2.Close()
        My.Computer.Network.UploadFile(accounttempfile, Service_Register & User & ".ini", User1, Pass1)
        My.Computer.Network.UploadFile(tempparam1, Service_Register & User & "_param1.json", User1, Pass1)
        My.Computer.Network.UploadFile(tempparam2, Service_Register & User & "_param2.json", User1, Pass1)
        Kill(accounttempfile)
        Kill(tempparam1)
        Kill(tempparam2)
    End Sub
    Public Sub Login(ByVal User As String, ByVal Pass As String)
        Dim ServiceLogin As String = ("") ''De même
        Dim accounttempfile As String = (My.Computer.FileSystem.SpecialDirectories.Temp & "\tempaccount.ini")
        Dim User1 As String = "" '' user ftp
        Dim Pass1 As String = "" '' mot de passe ftp
        Try
            My.Computer.Network.DownloadFile(ServiceLogin & User & ".ini", accounttempfile, User1, Pass1)
        Catch ex As Exception
            exeption("Ce compte n'existe pas !")
            Form1.TextBox1.Clear()
            Form1.TextBox2.Clear()
            Form1.TextBox1.Focus()
            Exit Sub
        End Try
        Dim sr As New StreamReader(accounttempfile)
        Dim Response As String = sr.ReadLine()
        If Response = Pass Then
            My.Settings.user = User
            My.Settings.Save()
            Form2.Show()
            Form1.Close()
        Else
            exeption("Le Mot de passe entré est erroné !")
        End If
        sr.Close()
        Kill(accounttempfile)
    End Sub
    Public Sub WriteParams(ByVal User As String)
        Dim ServiceCheckParam1 As String = ("" & User & "_param1.json") ''Vôtre ftp comme avant
        Dim ServiceCheckParam2 As String = ("" & User & "_param2.json") '' de même
        Dim paramsfile1 As String = (My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\param1.json")
        Dim paramsfile2 As String = (My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\param2.json")
        Dim tempfile1 As String = (My.Computer.FileSystem.SpecialDirectories.Temp & "\_param1.json")
        Dim tempfile2 As String = (My.Computer.FileSystem.SpecialDirectories.Temp & "\_param2.json")
        Dim User1 As String = "" '' user ftp
        Dim Pass1 As String = "" '' mot de passe ftp
        My.Computer.Network.DownloadFile(ServiceCheckParam1, tempfile1, User1, Pass1)
        My.Computer.Network.DownloadFile(ServiceCheckParam2, tempfile2, User1, Pass1)
        Dim sw1 As New StreamWriter(paramsfile1)
        Dim sw2 As New StreamWriter(paramsfile2)
        Dim sr1 As New StreamReader(tempfile1)
        Dim sr2 As New StreamReader(tempfile2)
        Dim temp1 As String = sr1.ReadLine
        Dim temp2 As String = sr2.ReadLine
        If temp1 = "Premium=false" Then
            sw1.Write("Premium=false")
        End If
        If temp1 = "Premium=true" Then
            sw1.Write("Premium=true")
        End If
        If temp2 = "Banned=false" Then
            sw2.Write("Banned=false")
        End If
        If temp2 = "Banned=true" Then
            sw2.Write("Banned=true")
        End If
        sw1.Close()
        sw2.Close()
        sr1.Close()
        sr2.Close()
        Kill(My.Computer.FileSystem.SpecialDirectories.Temp & "\_param1.json")
        Kill(My.Computer.FileSystem.SpecialDirectories.Temp & "\_param2.json")
    End Sub
    Sub ReadParams()
        Dim paramsfile1 As String = (My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\param1.json")
        Dim paramsfile2 As String = (My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\param2.json")
        Dim sr1 As New StreamReader(paramsfile1)
        Dim sr2 As New StreamReader(paramsfile2)
        Dim ContentParam1 As String = sr1.ReadLine
        Dim ContentParam2 As String = sr2.ReadLine
        If ContentParam1 = "Premium=true" Then
            Form2.Label1.Text = "Premium: OUI"
        End If


        sr1.Close()
        sr2.Close()
        Kill(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\param1.json")
        Kill(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\param2.json")
    End Sub
End Module
