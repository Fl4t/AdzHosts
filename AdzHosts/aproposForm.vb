Public Class aproposForm

    Private Sub ForumLinkLabel_LinkClicked(ByVal sender As System.Object, _
                                           ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) _
                                    Handles ForumLinkLabel.LinkClicked
        ' Lance le navigateur par défaut vers le forum.
        System.Diagnostics.Process.Start("http://adzhosts.free.fr/forum/")
    End Sub

    Private Sub SiteLinkLabel_LinkClicked(ByVal sender As System.Object, _
                                          ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) _
                                    Handles SiteLinkLabel.LinkClicked
        ' Lance le navigateur par défaut vers le site.
        System.Diagnostics.Process.Start("http://adzhosts.fr")
    End Sub

End Class