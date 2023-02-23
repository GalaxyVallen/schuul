Imports System.Data.OleDb

Public Class Form1
    'membuat objek koneksi dan adapter
    Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=dbabsen.accdb;"
    Dim conn As New OleDbConnection(connString)
    Dim adapter As New OleDbDataAdapter()

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'memuat data dari database dan menampilkan pada datagridview
        Dim ds As New DataSet()
        adapter.SelectCommand = New OleDbCommand("SELECT * FROM Absensi", conn)
        adapter.Fill(ds, "Absensi")
        DataGridView1.DataSource = ds.Tables("Absensi")

        'menambahkan pilihan pada combobox1
        ComboBox1.Items.Add("X")
        ComboBox1.Items.Add("XI")
        ComboBox1.Items.Add("XII")

        'menambahkan pilihan pada combobox3
        ComboBox3.Items.Add("Hadir")
        ComboBox3.Items.Add("Izin")
        ComboBox3.Items.Add("Sakit")
        ComboBox3.Items.Add("Alpa")
    End Sub

    Private Sub btnsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsimpan.Click
        'menambah data ke database
        Dim cmd As New OleDbCommand("INSERT INTO absensi (Nama, Kelas, Mata_Pelajaran, Keterangan, Tanggal) VALUES (@Nama, @Kelas, @Mata_Pelajaran, @Keterangan, @Tanggal)", conn)
        cmd.Parameters.AddWithValue("@Nama", TextBox1.Text)
        cmd.Parameters.AddWithValue("@Kelas", ComboBox1.Text)
        cmd.Parameters.AddWithValue("@Mata_Pelajaran", ComboBox2.Text)
        cmd.Parameters.AddWithValue("@Keterangan", ComboBox3.Text)
        cmd.Parameters.AddWithValue("@Tanggal", DateTimePicker1.Value)
        conn.Open()
        cmd.ExecuteNonQuery()
        conn.Close()

        MsgBox("Data telah ditambahkan.")
        RefreshData()
    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        'mengupdate data di database
        Dim cmd As New OleDbCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "UPDATE Absensi SET Nama=@nama, Kelas=@kelas, Mata_Pelajaran=@mapel, Keterangan=@hadir, Tanggal=@waktu WHERE id=@id"
        cmd.Parameters.AddWithValue("@nama", TextBox1.Text)
        cmd.Parameters.AddWithValue("@kelas", ComboBox1.Text)
        cmd.Parameters.AddWithValue("@mapel", ComboBox2.Text)
        cmd.Parameters.AddWithValue("@hadir", ComboBox3.Text)
        cmd.Parameters.AddWithValue("@waktu", DateTimePicker1.Value)
        cmd.Parameters.AddWithValue("@id", DataGridView1.CurrentRow.Cells("id").Value.ToString())
        cmd.Connection = conn

        conn.Open()
        cmd.ExecuteReader()
        conn.Close()

        MsgBox("Data telah diupdate.")
        RefreshData()
    End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        'memuat data dari database dan menampilkan pada datagridview
        Dim ds As New DataSet()
        adapter.SelectCommand = New OleDbCommand("SELECT * FROM Absensi", conn)
        Dim builder As New OleDbCommandBuilder(adapter)
        adapter.Fill(ds, "Absensi")
        DataGridView1.DataSource = ds.Tables("Absensi")

        'mengosongkan TextBox, ComboBox, dan DateTimePicker
        TextBox1.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        DateTimePicker1.Value = Date.Now

        MsgBox("Data Telah di Refresh")
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        'menampilkan data ke TextBox, ComboBox, DateTimePicker
        TextBox1.Text = DataGridView1.CurrentRow.Cells("Nama").Value.ToString()
        ComboBox1.Text = DataGridView1.CurrentRow.Cells("Kelas").Value.ToString()
        ComboBox2.Text = DataGridView1.CurrentRow.Cells("Mata_Pelajaran").Value.ToString()
        ComboBox3.Text = DataGridView1.CurrentRow.Cells("Keterangan").Value.ToString()
    End Sub

    Private Sub RefreshData()
        'memuat data dari database dan menampilkan pada datagridview
        Dim ds As New DataSet()
        adapter.SelectCommand = New OleDbCommand("SELECT * FROM Absensi", conn)
        Dim builder As New OleDbCommandBuilder(adapter)
        adapter.Fill(ds, "Absensi")
        DataGridView1.DataSource = ds.Tables("Absensi")

        'membersihkan kolom input
        TextBox1.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        DateTimePicker1.Value = DateTime.Now
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "X" Then
            'jika kelas X dipilih, maka pilihan pada ComboBox mata pelajaran hanya IPA, IPS, dan KIMIA
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("IPA")
            ComboBox2.Items.Add("IPS")
            ComboBox2.Items.Add("KIMIA")
        Else
            'jika kelas selain X dipilih, maka pilihan pada ComboBox mata pelajaran adalah semua pilihan
            ComboBox2.Items.Clear()
            ComboBox2.Items.Add("IPA")
            ComboBox2.Items.Add("IPS")
            ComboBox2.Items.Add("FISIKA")
            ComboBox2.Items.Add("KIMIA")
        End If
    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        Dim cmd As New OleDbCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "DELETE FROM absensi WHERE id=@id"
        cmd.Parameters.AddWithValue("@id", DataGridView1.CurrentRow.Cells("Nama").Value.ToString())
        cmd.Connection = conn

        conn.Open()
        cmd.ExecuteNonQuery()
        conn.Close()

        MsgBox("Data telah dihapus.")
        RefreshData()
    End Sub
End Class

