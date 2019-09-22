Imports MySql.Data.MySqlClient

Public Class Menu
    Inherits System.Windows.Forms.Form
    

    Private Sub Menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connection()
        InputToolStripMenuItem.Visible = False
        DataToolStripMenuItem.Visible = False
        LogoutToolStripMenuItem.Visible = False
        'If status = True Then
        '    ToolStripStatusLabel2.Text = "connected"
        '    ToolStripStatusLabel2.ForeColor = Color.White

        'Else
        '    ToolStripStatusLabel2.Text = "not connected"
        '    ToolStripStatusLabel2.ForeColor = Color.Yellow
        'End If
    End Sub

    Private Sub AnggotaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnggotaToolStripMenuItem.Click
        Anggota.Show()
    End Sub

    Private Sub AnggotaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnggotaToolStripMenuItem1.Click
        InputAnggot.Show()
    End Sub

    Private Sub PengurusToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PengurusToolStripMenuItem1.Click
        InputPengurus.Show()
    End Sub

    Private Sub PengurusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PengurusToolStripMenuItem.Click
        Pengurus.Show()
    End Sub

    Private Sub PemasukanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PemasukanToolStripMenuItem.Click
        InputPemasukan.Show()
    End Sub

    Private Sub PengeluaranToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PengeluaranToolStripMenuItem.Click
        InputPengeluaran.Show()
    End Sub

    Private Sub PemasukanToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PemasukanToolStripMenuItem2.Click
        TransaksiPemasukan.Show()
    End Sub

    Private Sub PengeluaranToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PengeluaranToolStripMenuItem1.Click
        TransaksiPengeluaran.Show()
    End Sub

    Private Sub LoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoginToolStripMenuItem.Click
        Login.Show()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        logout()
    End Sub
End Class
