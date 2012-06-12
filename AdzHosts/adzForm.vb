  ' Copyright (c) 2012 Stechele Julien
' All rights reserved.

' Redistribution and use in source and binary forms, with or without modification, are permitted provided 
' that the following conditions are met:

' * Redistributions of source code must retain the above copyright notice, this list of conditions and 
' the following disclaimer.
' * Redistributions in binary form must reproduce the above copyright notice, this list of conditions 
' and the following disclaimer in the documentation and/or other materials provided with the distribution.
' * Neither the name of the copyright holder nor the names of its contributors may be used to endorse 
' or promote products derived from this software without specific prior written permission.

' THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED 
' WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
' PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR 
' ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
' LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
' INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,WHETHER IN CONTRACT, STRICT LIABILITY, 
' OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE
' USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

Public Class adzForm

    ' Représente le chemin ou se trouve le fichier hosts sur le système.
    Private mstrCheminHostsLocale As String = System.Environment.SystemDirectory.Remove(2) _
                                                & "\Windows\System32\drivers\etc\HOSTS"

    ' Représente le chemin du fichier serveur dans le dossier de l'application.
    Private mstrCheminHostsServeur As String = Application.StartupPath & "\hostsServeur.txt"

    ' Représente le chemin du fichier serveur dans le dossier de l'application, mais purifié.
    Private mstrCheminHostsPur As String = Application.StartupPath & "\hostsPur.txt"

    ' Représente le chemin du fichier temporaire.
    Private mstrCheminHostsTemp As String = Application.StartupPath & "\hostsTemp.txt"

    ' Représente la version du fichier serveur analysé par la fonction de vérification de version
    Private mstrVersionServeur As String

    ' Représente la version du fichier locale analysé par la fonction de vérification de version
    Private mstrVersionLocale As String

    Private Sub adzForm_Load(ByVal sender As System.Object,
                             ByVal e As System.EventArgs) _
                             Handles MyBase.Load
        If isWindowsAdministrator() Then
            Call P_EnleverLectureSeule()
            DLBackgroundWorker.RunWorkerAsync()
        Else
            MessageBox.Show("Vous n'avez pas les autorisations nécessaires pour modifier le " _
                           & "fichier hosts de l'ordinateur. Assurez-vous d'avoir les accès " _
                           & "administrateurs et d'avoir désactiver le service UAC de Windows.",
                           "Accès refusé", MessageBoxButtons.OK, MessageBoxIcon.Error,
                           MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Public Function isWindowsAdministrator() As Boolean
        My.User.InitializeWithWindowsUser()
        If My.User.IsAuthenticated Then
            If My.User.IsInRole(Microsoft.VisualBasic.ApplicationServices.BuiltInRole.Administrator) Then
                Return True
            End If
        End If
        Return False
    End Function

    Private Sub DLBackgroundWorker_DoWork(ByVal sender As System.Object,
                                          ByVal e As System.ComponentModel.DoWorkEventArgs) _
                                          Handles DLBackgroundWorker.DoWork
        Try
            My.Computer.Network.DownloadFile("http://kosvocore.free.fr/AdZHosts/HOSTS",
                                             mstrCheminHostsServeur, "", "", False, 1000, True)
        Catch ex As Exception
            MessageBox.Show("Problème lors du téléchargement, vérifiez que votre connexion " & _
                "internet fonctionne et assurez-vous que le fichier hosts est " & _
                "distribué à l'adresse suivante : http://kosvocore.free.fr/AdZHosts/HOSTS ",
                "AdZHosts Updater", MessageBoxButtons.OK,
                MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub DLBackgroundWorker_RunWorkerCompleted(ByVal sender As Object,
                                                ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) _
                                                Handles DLBackgroundWorker.RunWorkerCompleted
        DLProgressBar.Visible = False
        DLLabel.Visible = False
        If Not (e.Error Is Nothing) Then
            MessageBox.Show(e.Error.Message)
        Else
            Call P_AnalyseDeVersion(mstrCheminHostsServeur)
            Call P_AnalyseDeVersion(mstrCheminHostsLocale)
            Call P_AffichageDesVersions()
            SyncButton.Enabled = True
            MiseAZeroToolStripMenuItem.Enabled = True
            AjoutDeDomainesToolStripMenuItem.Enabled = True
            SuppressionDeDomainesToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub P_AnalyseDeVersion(ByVal pp_strCheminHosts As String)
        Dim vp_objFichierHosts As System.IO.StreamReader
        If pp_strCheminHosts = mstrCheminHostsServeur Then
            vp_objFichierHosts = System.IO.File.OpenText(pp_strCheminHosts)
            mstrVersionServeur = F_VerifierVersion(vp_objFichierHosts)
            vp_objFichierHosts.Close()
        Else
            If System.IO.File.Exists(pp_strCheminHosts) Then
                vp_objFichierHosts = System.IO.File.OpenText(pp_strCheminHosts)
                mstrVersionLocale = F_VerifierVersion(vp_objFichierHosts)
                vp_objFichierHosts.Close()
            Else
                MessageBox.Show("Fichier non trouvé dans l'emplacement " & mstrCheminHostsLocale & ".",
                                            "AdZHosts Updater", MessageBoxButtons.OK, MessageBoxIcon.Error)
                mstrVersionLocale = "Aucun"
            End If
        End If
    End Sub

    Private Sub P_AffichageDesVersions()
        Select Case mstrVersionLocale.CompareTo(mstrVersionServeur)
            Case Is < 0
                ServeurLabel.ForeColor = Color.Green
                LocaleLabel.ForeColor = Color.Red
            Case Is > 0
                ServeurLabel.ForeColor = Color.Red
                LocaleLabel.ForeColor = Color.Green
            Case Else
                ServeurLabel.ForeColor = Color.Green
                LocaleLabel.ForeColor = Color.Green
        End Select
        LocaleLabel.Text = mstrVersionLocale
        ServeurLabel.Text = mstrVersionServeur
        If mstrVersionServeur = "Inconnu" Then
            MessageBox.Show("Le fichier ne contient pas la chaine '# AdZHosts...'," & _
                        " il est possible que le fichier soit corrompu ou que le mainteneur " & _
                        "est changer la norme de présentation." & vbNewLine & _
                        "Je vous invite à consulter le forum :" & _
                        vbNewLine & "http://adzhosts.free.fr/forum/", "AdZHosts Updater",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            SyncButton.Enabled = False
        End If
    End Sub

    Private Function F_VerifierVersion(ByRef pf_objFichierHosts As System.IO.StreamReader) As String
        Dim vf_strVersion As String
        Dim vf_strLigneEnCours As String = ""
        ' Une erreur si le fichier fait moins de 2 lignes, donc on test avant.
        Try
            For intLigne = 1 To 2
                vf_strLigneEnCours = pf_objFichierHosts.ReadLine()
            Next
            ' On recherche le caractère "v" dans la ligne.
            Dim intPosition As Integer = vf_strLigneEnCours.IndexOf("v")

            ' Si le caractère "v" est trouvé sur la ligne en cours, on extrait les quatres caractères.
            If intPosition <> -1 Then
                vf_strVersion = vf_strLigneEnCours.Substring(intPosition + 1, 4)
            Else
                vf_strVersion = "Inconnu"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            vf_strVersion = "Inconnu"
        End Try
        Return vf_strVersion
    End Function

    Private Sub P_Purification()
        ' Cette procédure consiste à analyser ligne par ligne le fichier hosts pour en vérifier sa conformité.
        ' En effet, dans le cas de piratage du fichier, une personne mal intentionnée pourrait y déposer des 
        ' lignes redirigeant vers des adresses ip différentes que "localhost" et donc, rediriger le site 
        ' www.paypal.com sur un serveur pirate. On supprime donc toutes lignes commençant par une 
        ' ip différente de localhost.

        ' On ouvre le fichier hosts provenant du serveur en lecture.
        Dim vp_objFichierHostsServeur As System.IO.StreamReader
        vp_objFichierHostsServeur = System.IO.File.OpenText(mstrCheminHostsServeur)
        ' On ouvre un fichier temporaire en écriture qui représente le fichier purifié.
        Dim vp_objFichierHostsServeurPur As System.IO.StreamWriter
        vp_objFichierHostsServeurPur = System.IO.File.CreateText(mstrCheminHostsPur)
        ' On déclare un tableau de chaîne qui contiendra les lignes qui n'ont pas été ajouté
        ' avec une variable pour incrémenter le tableau et une autre qui représente la longueur totale
        ' du tableau.
        Dim vp_strLignesExclus() As String = {""}
        Dim vp_intIndice As Integer = 1
        Dim vp_intLongueur As Integer = 2
        Dim vp_strLigneEnCours As String
        Do While vp_objFichierHostsServeur.Peek <> -1
            vp_strLigneEnCours = vp_objFichierHostsServeur.ReadLine()
            If vp_strLigneEnCours.StartsWith("127.0.0.1") Or _
                                    vp_strLigneEnCours.StartsWith("::1") Or _
                                    vp_strLigneEnCours.StartsWith("255.255.255.255") Or _
                                     vp_strLigneEnCours.StartsWith("#") Then
                vp_objFichierHostsServeurPur.WriteLine(vp_strLigneEnCours)
            ElseIf vp_strLigneEnCours.Trim <> "" Then
                ' On ajoute le reste au tableau si c'est pas une ligne vide.
                ReDim Preserve vp_strLignesExclus(vp_intLongueur)
                vp_strLignesExclus(vp_intIndice) = vp_strLigneEnCours
                vp_intIndice += 1
                vp_intLongueur += 1
            End If
        Loop
        vp_objFichierHostsServeur.Close()
        vp_objFichierHostsServeurPur.Close()
        ' On affiche les lignes qui n'ont pas été inclut dans le fichier.
        If vp_strLignesExclus.Length <> 1 Then
            Dim vp_strLigne As String = ""
            For vp_intLigne = 1 To vp_strLignesExclus.Length - 1
                vp_strLigne += vp_strLignesExclus(vp_intLigne) & vbNewLine
            Next
            MsgBox("Les lignes suivantes n'ont pas été inscrites : " & vbNewLine & vbNewLine & vp_strLigne,
                    MsgBoxStyle.OkOnly, "AdZHosts Updater")
        End If
    End Sub

    Private Sub P_EnleverLectureSeule()
        If System.IO.File.Exists(mstrCheminHostsLocale) Then
            Dim acces As FileAttribute = System.IO.File.GetAttributes(mstrCheminHostsLocale)
            If (acces And FileAttribute.ReadOnly) = FileAttribute.ReadOnly Then
                System.IO.File.SetAttributes(mstrCheminHostsLocale, acces And Not FileAttribute.ReadOnly)
            End If
        End If
    End Sub

    Private Sub P_RemplacerHostLocal(ByRef pf_strCheminHostsNouveau As String, _
                                     ByVal pf_strCheminHostsAncien As String)
        System.IO.File.Copy(pf_strCheminHostsNouveau, pf_strCheminHostsAncien, True)
        System.IO.File.Delete(pf_strCheminHostsNouveau)
    End Sub

    Private Sub SyncButton_Click(ByVal sender As System.Object,
                                 ByVal e As System.EventArgs) _
                                 Handles SyncButton.Click
        Dim dlgReponse As DialogResult
        dlgReponse = MessageBox.Show("Etes-vous sur le vouloir procéder à la mise à jour ?",
                                       "AdZHosts Updater", MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2)
        If dlgReponse = Windows.Forms.DialogResult.Yes Then
            Call P_Purification()
            Call P_RemplacerHostLocal(mstrCheminHostsPur, mstrCheminHostsLocale)
            MessageBox.Show("Mise à jour réussie !", "AdZHosts Updater", MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
            Call P_AnalyseDeVersion(mstrCheminHostsLocale)
            Call P_AffichageDesVersions()
        Else
            MessageBox.Show("Mise à jour interrompue.", "AdZHosts Updater", MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub MiseAZeroToolStripMenuItem_Click(ByVal sender As System.Object,
                                                 ByVal e As System.EventArgs) _
                                                 Handles MiseAZeroToolStripMenuItem.Click
        Dim dlgReponse As DialogResult
        dlgReponse = MessageBox.Show("Etes-vous sur de vouloir remettre à zéro le fichier hosts ?",
                                       "AdZHosts Updater", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                       MessageBoxDefaultButton.Button2)
        If dlgReponse = Windows.Forms.DialogResult.Yes Then
            ' On déclare une variable représentant le chemin du fichier hostsdefaut.txt
            Dim strCheminHostsDefaut As String = Application.StartupPath & "\hostsDefaut.txt"
            Dim objFichierHostsDefaut As System.IO.StreamWriter
            objFichierHostsDefaut = System.IO.File.CreateText(strCheminHostsDefaut)
            ' On y place une présentation ainsi que la ligne obligatoire.
            objFichierHostsDefaut.WriteLine("# Hosts")
            objFichierHostsDefaut.WriteLine("#")
            objFichierHostsDefaut.WriteLine("127.0.0.1 localhost")
            ' On ferme le fichier
            objFichierHostsDefaut.Close()
            Call P_RemplacerHostLocal(strCheminHostsDefaut, mstrCheminHostsLocale)
            MessageBox.Show("Mise à zéro éffectuée !", "AdZHosts Updater", MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Call P_AnalyseDeVersion(mstrCheminHostsLocale)
            Call P_AffichageDesVersions()
        End If
    End Sub

    Private Sub AjoutDeDomainesToolStripMenuItem_Click(ByVal sender As System.Object, _
                                                       ByVal e As System.EventArgs) _
                                                       Handles AjoutDeDomainesToolStripMenuItem.Click
        Dim strDomaineAjout As String = InputBox("Si votre ajout est susceptible d'intéresser la communauté" _
                                                 & ", n'hésitez pas à proposer votre nom de domaine sur le " _
                                                 & "forum." & vbNewLine & _
                                                 "Adresse : http://adzhosts.free.fr/forum/",
                                                 "AdZHosts Updater", "domaine.com")
        If strDomaineAjout <> "" AndAlso strDomaineAjout <> "domaine.com" Then
            Dim objFichierHostsLocale As System.IO.StreamWriter
            objFichierHostsLocale = System.IO.File.AppendText(mstrCheminHostsLocale)
            objFichierHostsLocale.WriteLine("127.0.0.1 " & strDomaineAjout)

            objFichierHostsLocale.Close()
            MessageBox.Show("Ajout reussi !", "AdZHosts Updater", MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
        Else
            MessageBox.Show("Vous n'avez pas saisi de nom de domaine !", "AdZHosts Updater", MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub SuppressionDeDomainesToolStripMenuItem_Click(ByVal sender As System.Object,
                                                             ByVal e As System.EventArgs) _
                                                             Handles SuppressionDeDomainesToolStripMenuItem.Click
        Dim strDomaineASuppr As String = InputBox("Si votre suppression est susceptible d'intéresser " & _
                                                  "la communauté, n'hésitez pas à proposer votre nom " & _
                                                  "de domaine sur le forum." & vbNewLine & _
                                                  "Adresse : http://adzhosts.free.fr/forum/",
                                                  "AdZHosts Updater", "domaine.com")
        If strDomaineASuppr <> "" AndAlso strDomaineASuppr <> "domaine.com" Then
            Dim objFichierHostsLocale As System.IO.StreamReader
            objFichierHostsLocale = System.IO.File.OpenText(mstrCheminHostsLocale)
            Dim objFichierHostsTemp As System.IO.StreamWriter
            objFichierHostsTemp = System.IO.File.CreateText(mstrCheminHostsTemp)
            Dim intPosition As Integer
            Dim boolTrouve As Boolean = False
            While objFichierHostsLocale.Peek <> -1
                Dim strLigneEnCours As String = objFichierHostsLocale.ReadLine()
                intPosition = strLigneEnCours.IndexOf(strDomaineASuppr)
                If intPosition = -1 Then
                    objFichierHostsTemp.WriteLine(strLigneEnCours)
                Else
                    boolTrouve = True
                    strLigneEnCours = strLigneEnCours.Remove(intPosition, strDomaineASuppr.Length)
                    If strLigneEnCours.Trim <> "127.0.0.1" Then
                        objFichierHostsTemp.WriteLine(strLigneEnCours)
                    End If
                End If
            End While
            objFichierHostsLocale.Close()
            objFichierHostsTemp.Close()
            Call P_RemplacerHostLocal(mstrCheminHostsTemp, mstrCheminHostsLocale)
            If boolTrouve Then
                MessageBox.Show("Suppression reussi !", "AdZHosts Updater", MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
            Else
                MessageBox.Show("Domaine proposé non trouvé, vérifiez votre syntaxe.",
                                "AdZHosts Updater", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Vous n'avez pas saisi de nom de domaine !", "AdZHosts Updater", MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub QuitterButton_Click(ByVal sender As System.Object,
                                    ByVal e As System.EventArgs) _
                                    Handles QuitterButton.Click, QuitterToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AProposToolStripMenuItem_Click(ByVal sender As System.Object,
                                               ByVal e As System.EventArgs) _
                                               Handles AProposToolStripMenuItem.Click
        Dim objaproposForm As New aproposForm
        objaproposForm.ShowDialog()
    End Sub

End Class
