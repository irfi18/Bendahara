Public Class TransaksiPengeluaran

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Laporan As New TransaksiKeluar
        CrystalReportViewer1.ReportSource = Laporan
        CrystalReportViewer1.SelectionFormula = "{pengeluaran1.tanggal}>=Date('" & DateTimePicker1.Value & "') And {pengeluaran1.tanggal}<=Date('" & DateTimePicker2.Value & "')"
        CrystalReportViewer1.Refresh()
        CrystalReportViewer1.Show()
    End Sub

    Private Sub TransaksiPengeluaran_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CrystalReportViewer1.Refresh()
    End Sub
End Class