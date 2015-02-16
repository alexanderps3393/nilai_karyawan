Public Class FormFilter2

    Private koneksi As New KoneksiDB

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub btnCari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCari.Click
        Dim cariKaryawan As New DialogCariKaryawan
        Dim hasil As DialogResult = cariKaryawan.ShowDialog(Me)
        If hasil = Windows.Forms.DialogResult.OK Then
            txtCariKaryawan.Text = cariKaryawan.id
            txtNamaKaryawan.Text = cariKaryawan.nama
            txtDepartemen.Text = cariKaryawan.departemen
            txtGolongan.Text = cariKaryawan.golongan
            If cariKaryawan.jk = "L" Then
                txtJenisKelamin.Text = "Laki-laki"
            Else
                txtJenisKelamin.Text = "Perempuan"
            End If
            txtAlamat.Text = cariKaryawan.alamat
        End If
    End Sub

    Private Sub FormFilter2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            koneksi.buka()
            koneksi.isiComboBox(ComboBox1, "periode_penilaian", "tahun_periode", "tahun_periode")
        Catch ex As Exception
            MessageBox.Show(Me, "Terjadi kesalahan!" & vbNewLine & "Sumber: " & ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ComboBox1.Text = Nothing Or ComboBox1.Text = "" Or txtCariKaryawan.Text = Nothing Or txtCariKaryawan.Text = "" Then
            MessageBox.Show(Me, "Mohon pilih karyawan dan tahun penilaian terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim laporan As New FormLaporan2
            laporan.SetTahun(ComboBox1.Text)
            laporan.SetKaryawan(txtCariKaryawan.Text)
            laporan.ShowDialog(Me)
        End If
    End Sub
End Class