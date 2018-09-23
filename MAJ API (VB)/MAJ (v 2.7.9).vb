Imports System.Net
Module MAJ
    Dim myversion As String = "1.0"
    Sub CheckMAJ()
        Try
            Dim maj As New WebClient
            Dim lastversion As String = maj.DownloadString("lien du fichier texte contenant la version")
            Dim downloadlink As String = maj.DownloadString("lien du fichier texte contenant le lien de la mise à jour")
            If myversion = lastversion Then
                MsgBox("Le logiciel est à jour ! (" & lastversion & ")", MsgBoxStyle.Information, "CHECK MISE A JOUR")
            Else
                MsgBox("Le logiciel n'est pas à jour !" & vbNewLine & "La dernière version est : " & lastversion, MsgBoxStyle.Critical, "CHECK MISE A JOUR")
                WebBrowser1.Navigate(downloadlink)
            End If
        Catch ex As Exception
            MsgBox("Une Erreur est survenue, essayez de redémarrez l'application ou vérifiez si vous êtes connecté au wifi.", MsgBoxStyle.Exclamation, MsgBoxStyle.OkOnly)
        End Try

    End Sub
End Module

