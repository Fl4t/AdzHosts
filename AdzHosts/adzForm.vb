
' Copyright (c) 2011 Stechele Julien
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

    ' Représente le chemin du dossier de sauvegardes.
    Private mstrCheminSauvegardes As String = Application.StartupPath & "\sauvegardes"

    ' Représente le chemin du fichier temporaire.
    Private mstrCheminHostsTemp As String = Application.StartupPath & "\hostsTemp.txt"

    ' Représente la version du fichier serveur analysé par la fonction de vérification de version
    Private mstrVersionServeur As String

    ' Représente la version du fichier locale analysé par la fonction de vérification de version
    Private mstrVersionLocale As String

    Private Sub adzForm_Load(ByVal sender As System.Object,
                             ByVal e As System.EventArgs) _
                             Handles MyBase.Load
        ' Au démarrage de l'application, on télécharge le fichier hosts à l'endroit où
        ' est l'executif.

        ' Essai du téléchargement, on ne sait jamais ce qui peut arriver.
        Try
            My.Computer.Network.DownloadFile("http://kosvocore.free.fr/AdZHosts/HOSTS", _
                                             mstrCheminHostsServeur, "", "", True, 10, True)
            ' Création du répertoire de sauvegardes.
            If System.IO.Directory.Exists(mstrCheminSauvegardes) = False Then
                System.IO.Directory.CreateDirectory(mstrCheminSauvegardes)
            End If
            ' On sauvegarde le fichier locale.
            Call P_SauvegardeHostsLocale()
            ' On analyse la version serveur.
            Call P_AnalyseDeVersion(mstrCheminHostsServeur)
            ' On analyse la version locale.
            Call P_AnalyseDeVersion(mstrCheminHostsLocale)

            ' On affiche les versions.
            Call P_AffichageDesVersions()
        Catch ex As Exception
            ' Si problème, on informe puis on bloque l'application.
            MessageBox.Show("Problème lors du téléchargement, vérifiez que votre connexion " & _
                            "internet fonctionne et assurez-vous que le fichier hosts est " & _
                            "distribué à l'adresse suivante : http://kosvocore.free.fr/AdZHosts/HOSTS ", _
                            "AdZHosts Updater", MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)
            SyncButton.Enabled = False
            MiseAZeroToolStripMenuItem.Enabled = False
            AjoutDeDomainesToolStripMenuItem.Enabled = False
            SuppressionDeDomainesToolStripMenuItem.Enabled = False
        End Try
    End Sub

    Private Sub P_SauvegardeHostsLocale()
        ' Sauvegarde du fichier hosts locale au lancement de l'application.

        ' On vérifie si le fichier existe.
        Dim pp_boolExiste As Boolean = System.IO.File.Exists(mstrCheminHostsLocale)
        If pp_boolExiste Then
            ' On déclare un compteur pour sauvegarder de façon incrémenté.
            Dim vp_intCompteur As Integer = 1

            ' Tant que le fichier de sauvegarde existe, on incrémente.
            While System.IO.File.Exists(mstrCheminSauvegardes & "\hostsSav" & vp_intCompteur)
                vp_intCompteur += 1
            End While
            ' On enregistre à la suite des sauvegardes.
            System.IO.File.Copy(mstrCheminHostsLocale, mstrCheminSauvegardes & "\hostsSav" & vp_intCompteur)
            ' Si il n'existe pas de fichier locale.
        Else
            Dim dlgReponse As DialogResult
            dlgReponse = MessageBox.Show("Fichier non trouvé dans l'emplacement " & mstrCheminHostsLocale & _
                                                       ", voulez-vous y placer le fichier hosts téléchargé ?", _
                                                       "AdZHosts Updater", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
            If dlgReponse = Windows.Forms.DialogResult.Yes Then
                ' On purifie le fichier avant de le copier.
                Call P_Purification()

                ' On copie le fichier purifié pour le mettre à l'emplacement prévu.
                System.IO.File.Copy(mstrCheminHostsPur, mstrCheminHostsLocale)

                ' On informe l'utilisateur de la reussite de l'opération.
                MessageBox.Show("Mise en place du fichier réussi !", "AdZHosts Updater", MessageBoxButtons.OK, _
                                                                                    MessageBoxIcon.Information)
                ' Puis la procédure ce rapelle-elle même pour forcément faire la copie et la sauvegarde.
                Call P_SauvegardeHostsLocale()
            End If
        End If
    End Sub

    Private Sub P_AnalyseDeVersion(ByVal pp_strCheminHosts As String)
        ' Cette procédure ouvre un fichier par rapport au chemin  mis en paramètre puis apelle 
        ' la fonction de vérification de version. Le but ici est de ne pas répéter le 
        ' code pour le load du formulaire et pour le code de la procédure évenementielle 
        ' click du menu AnalyserLesVersionsToolStripMenuItem.

        ' Si le chemin qui est donné en paramètre est le chemin du fichier téléchargé.
        If pp_strCheminHosts = mstrCheminHostsServeur Then
            ' On ouvre le fichier serveur, on extrait la version puis on le ferme.
            Dim vp_objFichierHostsServeur As System.IO.StreamReader
            vp_objFichierHostsServeur = System.IO.File.OpenText(pp_strCheminHosts)
            mstrVersionServeur = F_VerifierVersion(vp_objFichierHostsServeur)
            vp_objFichierHostsServeur.Close()
            ' Sinon c'est que c'est le chemin du fichier local.
        Else
            ' On ouvre le fichier local, on extrait la version puis on le ferme.
            Dim vp_objFichierHostsLocale As System.IO.StreamReader
            vp_objFichierHostsLocale = System.IO.File.OpenText(mstrCheminHostsLocale)
            mstrVersionLocale = F_VerifierVersion(vp_objFichierHostsLocale)
            vp_objFichierHostsLocale.Close()
        End If
    End Sub

    Private Sub P_AffichageDesVersions()
        ' Colorisations des versions.
        Select Case mstrVersionLocale.CompareTo(mstrVersionServeur)
            Case Is > 0
                ServeurLabel.ForeColor = Color.Green
                LocaleLabel.ForeColor = Color.Red
            Case Is < 0
                ServeurLabel.ForeColor = Color.Red
                LocaleLabel.ForeColor = Color.Green
            Case Else
                ServeurLabel.ForeColor = Color.Green
                LocaleLabel.ForeColor = Color.Green
        End Select

        ' On fait apparaître la version locale.
        LocaleLabel.Text = mstrVersionLocale

        ' On fait apparaître la version serveur.
        ServeurLabel.Text = mstrVersionServeur

        ' Si la version du fichier hosts est inconnu, il y a un problème.
        If mstrVersionServeur = "Inconnu" Then
            MessageBox.Show("Le fichier ne contient pas la chaine '# AdZHosts...'," & _
                        " il est possible que le fichier soit corrompu ou que le mainteneur " & _
                        "est changer la norme de présentation." & vbNewLine & _
                        "Je vous invite à consulter le forum :" & _
                        vbNewLine & "http://adzhosts.free.fr/forum/", "AdZHosts Updater", _
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            SyncButton.Enabled = False
        End If
    End Sub

    Private Function F_VerifierVersion(ByRef pf_objFichierHosts As System.IO.StreamReader) As String
        ' Cette fonction extrait une chaîne du fichier placée en paramètre représentant le numero de version
        ' sur 4 caractères. On envoie un fichier par valeur car le fichier peut être volumineux.

        Dim vf_strVersion As String
        Dim vf_strLigneEnCours As String = ""

        ' Une erreur si le fichier fait moins de 2 lignes, donc on test avant.
        Try
            ' On parcourt le fichier objFichierHosts jusqu'à la deuxième ligne.
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

        ' On place le reste du fichier tout en purifiant.
        Do While vp_objFichierHostsServeur.Peek <> -1
            vp_strLigneEnCours = vp_objFichierHostsServeur.ReadLine()
            ' Si une ligne du fichier commence par l'ip 127.0.0.1, on l'ajoute.
            ' Si une ligne du fichier commence par l'ip 255.255.255.255, on l'ajoute.
            ' Si une ligne du fichier commence par #, on l'ajoute.
            ' Si une ligne du fichier commence par ::1, on l'ajoute.
            If vp_strLigneEnCours.StartsWith("127.0.0.1") Or _
                                    vp_strLigneEnCours.StartsWith("::1") Or _
                                    vp_strLigneEnCours.StartsWith("255.255.255.255") Or _
                                     vp_strLigneEnCours.StartsWith("#") Then
                vp_objFichierHostsServeurPur.WriteLine(vp_strLigneEnCours)
            Else
                ' On ajoute le reste au tableau.
                ReDim Preserve vp_strLignesExclus(vp_intLongueur)
                vp_strLignesExclus(vp_intIndice) = vp_strLigneEnCours
                vp_intIndice += 1
                vp_intLongueur += 1
            End If
        Loop
        ' Fermeture des fichiers.
        vp_objFichierHostsServeur.Close()
        vp_objFichierHostsServeurPur.Close()

        ' On affiche les lignes qui n'ont pas été inclut dans le fichier.
        If vp_strLignesExclus.Length <> 1 Then
            Dim vp_strLigne As String = ""
            For vp_intLigne = 1 To vp_strLignesExclus.Length - 1
                vp_strLigne += vp_strLignesExclus(vp_intLigne) & vbNewLine
            Next
            MsgBox("Les lignes suivantes n'ont pas été inscrites : " & vbNewLine & vbNewLine & vp_strLigne, _
                    MsgBoxStyle.OkOnly, "AdZHosts Updater")
        End If
    End Sub

    Private Sub SyncButton_Click(ByVal sender As System.Object,
                                 ByVal e As System.EventArgs) _
                                 Handles SyncButton.Click
        ' Message de confirmation.
        Dim dlgReponse As DialogResult
        dlgReponse = MessageBox.Show("Etes-vous sur le vouloir procéder à la mise à jour ?", _
                                       "AdZHosts Updater", MessageBoxButtons.YesNo, _
                                       MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2)
        If dlgReponse = Windows.Forms.DialogResult.Yes Then
            ' Appel de la procédure de purification avant le remplacement du fichier dans la machine locale.
            Call P_Purification()

            ' Remplacement du fichier local par le fichier purifié.
            System.IO.File.Copy(mstrCheminHostsPur, mstrCheminHostsLocale, True)
            MessageBox.Show("Mise à jour réussie !", "AdZHosts Updater", MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)

            ' On analyse la version locale.
            Call P_AnalyseDeVersion(mstrCheminHostsLocale)
            ' On apelle l'affichage des versions.
            Call P_AffichageDesVersions()
        Else
            MessageBox.Show("Mise à jour interrompue.", "AdZHosts Updater", MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub MiseAZeroToolStripMenuItem_Click(ByVal sender As System.Object,
                                                 ByVal e As System.EventArgs) _
                                                 Handles MiseAZeroToolStripMenuItem.Click
        ' On demande une confirmation.
        Dim dlgReponse As DialogResult
        dlgReponse = MessageBox.Show("Etes-vous sur de vouloir remettre à zero le fichier hosts ?", _
                                       "AdZHosts Updater", MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                                       MessageBoxDefaultButton.Button2)
        If dlgReponse = Windows.Forms.DialogResult.Yes Then
            ' On déclare une variable représentant le chemin du fichier hostsdefaut.txt
            Dim strCheminHostsDefaut As String = Application.StartupPath & "\hostsDefaut.txt"
            Dim objFichierHostsDefaut As System.IO.StreamWriter

            ' On crée le fichier.
            objFichierHostsDefaut = System.IO.File.CreateText(strCheminHostsDefaut)

            ' On y place une présentation ainsi que la ligne obligatoire.
            objFichierHostsDefaut.WriteLine("# Hosts")
            objFichierHostsDefaut.WriteLine("#")
            objFichierHostsDefaut.WriteLine("127.0.0.1 localhost")

            ' On ferme le fichier
            objFichierHostsDefaut.Close()

            ' On le copie à l'emplacement prévu.
            System.IO.File.Copy(strCheminHostsDefaut, mstrCheminHostsLocale, True)

            ' On supprime le fichier.
            System.IO.File.Delete(strCheminHostsDefaut)

            ' On informe.
            MessageBox.Show("Mise à zéro éffectuée !", "AdZHosts Updater", MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)

            ' On apelle l'analyse des versions.
            Call P_AnalyseDeVersion(mstrCheminHostsLocale)
            ' On appelle l'affichage des versions.
            Call P_AffichageDesVersions()
        End If
    End Sub

    Private Sub AjoutDeDomainesToolStripMenuItem_Click(ByVal sender As System.Object, _
                                                       ByVal e As System.EventArgs) _
                                                       Handles AjoutDeDomainesToolStripMenuItem.Click
        ' Procédure évenementielle d'ajout de nom de domaine.
        ' On demande le nom de domaine à ajouter.
        Dim strDomaineAjout As String = InputBox("Si votre ajout est susceptible d'intéresser la communauté" _
                                                 & ", n'hésitez pas à proposer votre nom de domaine sur le " _
                                                 & "forum." & vbNewLine & _
                                                 "Adresse : http://adzhosts.free.fr/forum/", _
                                                 "AdZHosts Updater", "domaine.com")
        If strDomaineAjout <> "" AndAlso strDomaineAjout <> "domaine.com" Then
            ' On fait une sauvegarde à chaque opération sur le fichier.
            Call P_SauvegardeHostsLocale()

            ' On ouvre le fichier local en écriture.
            Dim objFichierHostsLocale As System.IO.StreamWriter
            objFichierHostsLocale = System.IO.File.AppendText(mstrCheminHostsLocale)

            ' On ajoute à la suite du fichier la ligne.
            objFichierHostsLocale.WriteLine("127.0.0.1 " & strDomaineAjout)

            ' On ferme le fichier puis on écrase le fichier précédent.
            objFichierHostsLocale.Close()

            ' On informe que l'ajout a reussi.
            MessageBox.Show("Ajout reussi !", "AdZHosts Updater", MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)
        Else
            ' On informe que l'ajout a été interrompue.
            MessageBox.Show("Vous n'avez pas saisi de nom de domaine !", "AdZHosts Updater", MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub SuppressionDeDomainesToolStripMenuItem_Click(ByVal sender As System.Object,
                                                             ByVal e As System.EventArgs) _
                                                             Handles SuppressionDeDomainesToolStripMenuItem.Click
        ' Procédure évenementielle de suppression de nom de domaine.
        ' On demande le nom de domaine à enlever.
        Dim strDomaineASuppr As String = InputBox("Si votre suppression est susceptible d'intéresser " & _
                                                  "la communauté, n'hésitez pas à proposer votre nom " & _
                                                  "de domaine sur le forum." & vbNewLine & _
                                                  "Adresse : http://adzhosts.free.fr/forum/", _
                                                  "AdZHosts Updater", "domaine.com")
        If strDomaineASuppr <> "" AndAlso strDomaineASuppr <> "domaine.com" Then
            ' On fait une sauvegarde à chaque changement du fichier.
            Call P_SauvegardeHostsLocale()

            ' On ouvre le fichier local en lecture.
            Dim objFichierHostsLocale As System.IO.StreamReader
            objFichierHostsLocale = System.IO.File.OpenText(mstrCheminHostsLocale)

            ' On crée un fichier temporaire.
            Dim objFichierHostsTemp As System.IO.StreamWriter
            objFichierHostsTemp = System.IO.File.CreateText(mstrCheminHostsTemp)

            ' On recherche dans le fichier le nom de domaine fourni.
            ' Il peut être plusieurs fois dans le fichier avec un suffixe différent.
            Dim intPosition As Integer
            ' Booléen indiquant si on a trouver le domaine
            Dim boolTrouve As Boolean = False
            While objFichierHostsLocale.Peek <> -1
                Dim strLigneEnCours As String = objFichierHostsLocale.ReadLine()

                ' Recherche du domaine dans la ligne en cours.
                intPosition = strLigneEnCours.IndexOf(strDomaineASuppr)
                If intPosition = -1 Then
                    objFichierHostsTemp.WriteLine(strLigneEnCours)
                Else
                    boolTrouve = True
                    strLigneEnCours = strLigneEnCours.Remove(intPosition, strDomaineASuppr.Length)

                    ' Si il ne reste plus que "127.0.0.1", on n'ajoute pas la ligne au fichier.
                    If strLigneEnCours.Trim <> "127.0.0.1" Then
                        objFichierHostsTemp.WriteLine(strLigneEnCours)
                    End If
                End If
            End While

            ' On ferme les fichiers puis on remplace.
            objFichierHostsLocale.Close()
            objFichierHostsTemp.Close()

            ' On copie le fichier temporaire puis on le colle à l'emplacement du fichier hosts.
            System.IO.File.Copy(mstrCheminHostsTemp, mstrCheminHostsLocale, True)
            If boolTrouve Then
                ' On informe que la suppréssion a reussi.
                MessageBox.Show("Suppression reussi !", "AdZHosts Updater", MessageBoxButtons.OK, _
                                MessageBoxIcon.Information)
            Else
                ' On informe que le domaine n'a pas été trouvé.
                MessageBox.Show("Domaine proposé non trouvé, vérifiez votre synthaxe.", _
                                "AdZHosts Updater", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            ' On informe que la suppréssion a été intérrompu.
            MessageBox.Show("Vous n'avez pas saisi de nom de domaine !", "AdZHosts Updater", MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub adzForm_FormClosing(ByVal sender As Object,
                                    ByVal e As System.Windows.Forms.FormClosingEventArgs) _
                                    Handles Me.FormClosing
        ' On supprime les fichiers.
        System.IO.File.Delete(mstrCheminHostsPur)
        System.IO.File.Delete(mstrCheminHostsServeur)
        System.IO.File.Delete(mstrCheminHostsTemp)
    End Sub

    Private Sub QuitterButton_Click(ByVal sender As System.Object,
                                    ByVal e As System.EventArgs) _
                                    Handles QuitterButton.Click, QuitterToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AProposToolStripMenuItem_Click(ByVal sender As System.Object,
                                               ByVal e As System.EventArgs) _
                                               Handles AProposToolStripMenuItem.Click
        ' On affiche le formulaire A propos.
        Dim objaproposForm As New aproposForm
        objaproposForm.ShowDialog()
    End Sub

End Class