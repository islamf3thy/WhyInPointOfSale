Imports System.IO
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Imaging
Public Class FrmItems
    Sub FillCategorizationName(SQL As String)
        CategorizationName.Items.Clear()

        Dim Adp = New SqlClient.SqlDataAdapter(SQL, SQLconn)
        Dim DS = New DataSet
        Adp.Fill(DS)
        Dim dt = DS.Tables(0)
        '--------------------------======================
        For I = 0 To dt.Rows.Count - 1
            CategorizationName.Items.Add(dt.Rows(I).Item("CategorizationName"))

        Next


    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        FrmCategorizations.ShowDialog()

    End Sub

    Private Sub CategorizationName_DropDown(sender As System.Object, e As System.EventArgs) Handles CategorizationName.DropDown
        FillCategorizationName("select * from Categorizations order by CategorizationName")

    End Sub

    Private Sub BtnNew_Click(sender As System.Object, e As System.EventArgs) Handles BtnNew.Click
        On Error Resume Next
        For i = 0 To GroupBox1.Controls.Count
            If TypeOf GroupBox1.Controls(i) Is TextBox Then GroupBox1.Controls(i).Text = ""
            If TypeOf GroupBox1.Controls(i) Is ComboBox Then GroupBox1.Controls(i).Text = ""
        Next

        For i = 0 To GroupBox2.Controls.Count
            If TypeOf GroupBox2.Controls(i) Is TextBox Then GroupBox2.Controls(i).Text = ""
            If TypeOf GroupBox2.Controls(i) Is ComboBox Then GroupBox2.Controls(i).Text = ""
        Next

        For i = 0 To GroupBox3.Controls.Count
            If TypeOf GroupBox3.Controls(i) Is TextBox Then GroupBox3.Controls(i).Text = ""
            If TypeOf GroupBox3.Controls(i) Is ComboBox Then GroupBox3.Controls(i).Text = ""

        Next

        For i = 0 To GroupBox4.Controls.Count
            If TypeOf GroupBox4.Controls(i) Is TextBox Then GroupBox4.Controls(i).Text = ""
            If TypeOf GroupBox4.Controls(i) Is ComboBox Then GroupBox4.Controls(i).Text = ""

        Next

        For i = 0 To GroupBox5.Controls.Count
            If TypeOf GroupBox5.Controls(i) Is TextBox Then GroupBox5.Controls(i).Text = ""
            If TypeOf GroupBox5.Controls(i) Is ComboBox Then GroupBox5.Controls(i).Text = ""

        Next

       
        For i = 0 To GroupBox7.Controls.Count
            If TypeOf GroupBox7.Controls(i) Is TextBox Then GroupBox7.Controls(i).Text = ""
            If TypeOf GroupBox7.Controls(i) Is ComboBox Then GroupBox7.Controls(i).Text = ""

        Next

        For i = 0 To GroupBox8.Controls.Count
            If TypeOf GroupBox8.Controls(i) Is PictureBox Then GroupBox8.Controls(i).Text = ""

        Next
        'GroupBox9.Visible = False
        'GroupBox1.Visible = True
        'GroupBox1.BringToFront()
        FromDate.Value = Now
        ToDate.Value = Now
        'SaleStrategy.SelectedIndex = 0
        UnitDefault.Checked = True
        PriceDefault6.Checked = True
        PicItem.Image = Nothing
        itemCode.Text = Format(GET_LAST_RECORD("Items", "itemInternal_ID") + 1, "ITMS000000")
        itemName.Focus()
        BtnSave.Enabled = True
        BtnEdit.Enabled = False
        BtnDelete.Enabled = False
        OpenFileDialog1.FileName = ""
    End Sub

    Private Sub BtnSave_Click(sender As System.Object, e As System.EventArgs) Handles BtnSave.Click
        If itemName.Text = "" Then
            MsgBox("أدخل اسم الصنف", MsgBoxStyle.Critical, "تعليمات")
            ErrorProvider1.SetError(itemName, "يرجى إدخال اسم الصنف")
            itemName.Focus()
            Exit Sub
        End If

        If CategorizationName.Text = "" Then
            MsgBox("أختر التصنيف الرئيسى للصنف", MsgBoxStyle.Critical, "تعليمات")
            ErrorProvider1.SetError(CategorizationName, "أدخل التصنيف الرئيسى للصنف")
            CategorizationName.Focus()
            Exit Sub
        End If

        If FirstUnit.Text = "" Then
            MsgBox("أدخل اسم الوحدة الاولى للصنف", MsgBoxStyle.Critical, "تعليمات")
            ErrorProvider1.SetError(FirstUnit, "أدخل اسم الوحدة الاولى للصنف")
            FirstUnit.Focus()
            Exit Sub
        End If

        Try
            Dim str = "select * from Items where itemName=N'" & itemName.Text.Trim & "'"
            Dim adp = New SqlClient.SqlDataAdapter(str, SQLconn)
            Dim ds = New DataSet
            adp.Fill(ds)
            Dim dt As DataTable
            dt = ds.Tables(0)
            If dt.Rows.Count > 0 Then
                MsgBox("إسم الصنف المدخل موجود مسبقا ، يرجى تغير اسم الصنف", MsgBoxStyle.Exclamation, "رسالة تنبيه")
                itemName.Focus()

            Else

                Dim dr = dt.NewRow
                '============================ البيانات الاساسية ========================

                dr!itemCode = itemCode.Text
                dr!itemName = itemName.Text
                dr!ItemSerial = ItemSerial.Text
                dr!ItemSerial2 = ItemSerial2.Text
                dr!CategorizationName = CategorizationName.Text
                dr!Size = _Size.Text
                dr!Size1 = Size1.Text
                dr!Origin = Origin.Text
                dr!Location = _Location.Text
                dr!Company = Company.Text
                dr!Color = _Color.Text
                dr!Provenance = Provenance.Text
                dr!Quality = Quality.Text
                dr!Model = Model.Text
                dr!adding = adding.Text
                dr!Note = Note.Text
                If ProductionDate.Text.Equals(String.Empty) Then dr!ProductionDate = ProductionDate.Text
                If ExpaireDate.Text.Equals(String.Empty) Then dr!ExpaireDate = ExpaireDate.Text
                dr!SaleStrategy = SaleStrategy.SelectedIndex
                dr!status = True
                '================================== الوحـــــــدات=================================
                dr!FirstUnit = FirstUnit.Text
                dr!FirstUnitBarcode = FirstUnitBarcode.Text

                dr!SecoundtUnit = SecoundtUnit.Text
                dr!SecoundtUnitBarcode = SecoundtUnitBarcode.Text
                dr!SecoundUnitOperatingConv = Val(SecoundUnitOperatingConv.Text)

                dr!ThirdUnit = ThirdUnit.Text
                dr!ThirdtUnitBarcode = ThirdtUnitBarcode.Text
                dr!ThirdUnitOperatingConv = Val(ThirdUnitOperatingConv.Text)
                dr!itemQuantity = itemQuantity.Text
                '====================================== خيارات الحدود ==================

                dr!MaxLimitForFirstUnite = Val(MaxLimitForFirstUnite.Text)
                dr!MinLimitForFirstUnite = Val(MinLimitForFirstUnite.Text)
                dr!OrderLimitForFirstUnite = Val(OrderLimitForFirstUnite.Text)

                dr!MaxLimitForSecoundUnite = Val(MaxLimitForSecoundUnite.Text)
                dr!MinLimitForSecoundUnite = Val(MinLimitForSecoundUnite.Text)
                dr!OrderLimitForSecoundUnite = Val(OrderLimitForSecoundUnite.Text)

                dr!MaxLimitForThirdUnite = Val(MaxLimitForThirdUnite.Text)
                dr!MinLimitForThirdUnite = Val(MinLimitForThirdUnite.Text)
                dr!OrderLimitForThirdUnite = Val(OrderLimitForThirdUnite.Text)

                If UnitDefault.Checked = True Then dr!UnitDefault = 1
                If UnitDefault2.Checked = True Then dr!UnitDefault = 2
                If UnitDefault3.Checked = True Then dr!UnitDefault = 3
                '=============================== اسعار البيع =====================
                Dim tableName As String = ""
                Dim str1 As String = ""
                Dim flg As Boolean = False
                'If SaleStrategy.SelectedIndex = 0 Then tableName = "ItemNormalPricess"
                'If SaleStrategy.SelectedIndex = 1 Then tableName = "ItemSeasonalPrices"
                'str1 = "select * from " & tableName & " where ItemCode=N'" & itemName.Text.Trim & "'"
                '===============================================================
                If SaleStrategy.SelectedIndex = 0 Then
                    str1 = "select * from ItemNormalPricess where ItemCode=N'" & itemName.Text.Trim & "'"
                ElseIf SaleStrategy.SelectedIndex = 1 Then
                    str1 = "select * from ItemSeasonalPrices where ItemCode=N'" & itemName.Text.Trim & "'"
                End If

                Dim adp1 = New SqlClient.SqlDataAdapter(str1, SQLconn)
                Dim ds1 = New DataSet
                adp1.Fill(ds1)
                Dim dt1 As DataTable
                dt1 = ds1.Tables(0)
                Dim dr1 As DataRow
                If dt1.Rows.Count = 0 Then
                    dr1 = dt1.NewRow
                    flg = False
                Else
                    dr1 = dt1.Rows(0)
                End If
                dr1!itemCode = itemCode.Text
                '--------1
                dr1!WholeSaleForFirstUnit = Val(WholeSaleForFirstUnit.Text)
                dr1!WholeSaleForSecondUnit = Val(WholeSaleForSecondUnit.Text)
                dr1!WholeSaleForThirdUnit = Val(WholeSaleForThirdUnit.Text)
                '--------2
                dr1!HalfWholeSaleForFirstUnit = Val(HalfWholeSaleForFirstUnit.Text)
                dr1!HalfWholeSaleForSecondUnit = Val(HalfWholeSaleForSecondUnit.Text)
                dr1!HalfWholeSaleForThirdUnit = Val(HalfWholeSaleForThirdUnit.Text)
                '--------3
                dr1!DistributorForFirstUnit = Val(DistributorForFirstUnit.Text)
                dr1!DistributorForSecondUnit = Val(DistributorForSecondUnit.Text)
                dr1!DistributorForThirdUnit = Val(DistributorForThirdUnit.Text)
                '--------
                dr1!ExportForFirstUnit = Val(ExportForFirstUnit.Text)
                dr1!ExportForSecondUnit = Val(ExportForSecondUnit.Text)
                dr1!ExportForThirdUnit = Val(ExportForThirdUnit.Text)
                '---------5
                dr1!RetailForFirstUnit = Val(RetailForFirstUnit.Text)
                dr1!RetailForSecondUnit = Val(RetailForSecondUnit.Text)
                dr1!RetailForThirdUnit = Val(RetailForThirdUnit.Text)
                '--------6
                dr1!EndUserForFirstUnit = Val(EndUserForFirstUnit.Text)
                dr1!EndUserForSecondUnit = Val(EndUserForSecondUnit.Text)
                dr1!EndUserForThirdUnit = Val(EndUserForThirdUnit.Text)

                dr1!AManufacturing = AManufacturing.Checked

                If SaleStrategy.SelectedIndex = 1 Then

                    dr1!FromDate = FromDate.Value
                    dr1!ToDate = ToDate.Value
                End If

                If PriceDefault1.Checked = True Then dr1!PriceDefault = 1
                If PriceDefault2.Checked = True Then dr1!PriceDefault = 2
                If PriceDefault3.Checked = True Then dr1!PriceDefault = 3
                If PriceDefault4.Checked = True Then dr1!PriceDefault = 4
                If PriceDefault5.Checked = True Then dr1!PriceDefault = 5
                If PriceDefault6.Checked = True Then dr1!PriceDefault = 6

                If flg = False Then dt1.Rows.Add(dr1)
                Dim cmd1 As New SqlClient.SqlCommandBuilder(adp1)
                adp1.Update(dt1)
                '========================= تشفير الصورة========================
                If OpenFileDialog1.FileName <> "" Then
                    Dim imgByteArrat() As Byte
                    Dim stream As New MemoryStream
                    PicItem.Image.Save(stream, ImageFormat.Jpeg)
                    imgByteArrat = stream.ToArray()
                    stream.Close()
                    dr!PicItem = imgByteArrat
                End If

                '==============================================

                dt.Rows.Add(dr)
                Dim cmd As New SqlClient.SqlCommandBuilder(adp)
                adp.Update(dt)
                BtnNew_Click(Nothing, Nothing)
                MsgBox("تم حفظ بيانات الصنف ف قاعدة البيانات بنجاح", MsgBoxStyle.Information, "رسالة تأكيد")

            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "فشل فى عملية الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
            'End Try
            MsgBox("فشل فى عملية الحفظ ، يرجى اعادة المحاولة لاحقا ", MsgBoxStyle.Critical, "خطأ")
        End Try
    End Sub

    Private Sub itemName_TextChanged(sender As System.Object, e As System.EventArgs) Handles itemName.TextChanged
        ErrorProvider1.SetError(itemName, "")
    End Sub

    Private Sub CategorizationName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CategorizationName.SelectedIndexChanged
        ErrorProvider1.SetError(CategorizationName, "")
    End Sub

    Private Sub FirstUnit_TextChanged(sender As System.Object, e As System.EventArgs) Handles FirstUnit.TextChanged
        ErrorProvider1.SetError(FirstUnit, "")

    End Sub

    Private Sub PicItem_Click(sender As System.Object, e As System.EventArgs) Handles PicItem.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "Jpeg|*.Jpg|Bitmap|*.Bmp|Gif|*.gif|Png|*.png"
        OpenFileDialog1.ShowDialog()
        If OpenFileDialog1.FileName = "" Then Exit Sub
        PicItem.Image = Image.FromFile(OpenFileDialog1.FileName)
    End Sub

    Private Sub BtnEdit_Click(sender As System.Object, e As System.EventArgs) Handles BtnEdit.Click
        If itemName.Text = "" Then
            MsgBox("أدخل اسم الصنف", MsgBoxStyle.Critical, "تعليمات")
            ErrorProvider1.SetError(itemName, "يرجى إدخال اسم الصنف")
            itemName.Focus()
            Exit Sub
        End If

        If CategorizationName.Text = "" Then
            MsgBox("أختر التصنيف الرئيسى للصنف", MsgBoxStyle.Critical, "تعليمات")
            ErrorProvider1.SetError(CategorizationName, "أدخل التصنيف الرئيسى للصنف")
            CategorizationName.Focus()
            Exit Sub
        End If

        If FirstUnit.Text = "" Then
            MsgBox("أدخل اسم الوحدة الاولى للصنف", MsgBoxStyle.Critical, "تعليمات")
            ErrorProvider1.SetError(FirstUnit, "أدخل اسم الوحدة الاولى للصنف")
            FirstUnit.Focus()
            Exit Sub
        End If
        '---============================================================================
        If MsgBox("سوف يتم حفظ هذة التعديلات , هل تريد الاستمرار ", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "رسالة") = MsgBoxResult.No Then Exit Sub
        Try
            Dim str = "select * from Items where itemCode=N'" & itemCode.Text.Trim & "'"
            Dim adp As New SqlClient.SqlDataAdapter(str, SQLconn)
            Dim ds As New DataSet
            adp.Fill(ds)
            Dim dt As DataTable
            dt = ds.Tables(0)
            If dt.Rows.Count = 0 Then
                MsgBox("رمز الصنف الذى تريد تعديل بياناته غير موجود", MsgBoxStyle.Exclamation, "رسالة تنبيه")

            Else
                Dim dr = dt.Rows(0)

                '============================ البيانات الاساسية ========================

                dr!itemCode = itemCode.Text
                dr!itemName = itemName.Text
                dr!ItemSerial = ItemSerial.Text
                dr!ItemSerial2 = ItemSerial2.Text
                dr!CategorizationName = CategorizationName.Text
                dr!Size = _Size.Text
                dr!Size1 = Size1.Text
                dr!Origin = Origin.Text
                dr!Location = _Location.Text
                dr!Company = Company.Text
                dr!Color = _Color.Text
                dr!Provenance = Provenance.Text
                dr!Quality = Quality.Text
                dr!Model = Model.Text
                dr!adding = adding.Text
                dr!Note = Note.Text
                If ProductionDate.Text.Equals(String.Empty) Then dr!ProductionDate = ProductionDate.Text
                If ExpaireDate.Text.Equals(String.Empty) Then dr!ExpaireDate = ExpaireDate.Text
                dr!SaleStrategy = SaleStrategy.SelectedIndex
                dr!status = True
                '================================== الوحـــــــدات=================================
                dr!FirstUnit = FirstUnit.Text
                dr!FirstUnitBarcode = FirstUnitBarcode.Text

                dr!SecoundtUnit = SecoundtUnit.Text
                dr!SecoundtUnitBarcode = SecoundtUnitBarcode.Text
                dr!SecoundUnitOperatingConv = Val(SecoundUnitOperatingConv.Text)

                dr!ThirdUnit = ThirdUnit.Text
                dr!ThirdtUnitBarcode = ThirdtUnitBarcode.Text
                dr!ThirdUnitOperatingConv = Val(ThirdUnitOperatingConv.Text)
                dr!itemQuantity = itemQuantity.Text
                '====================================== خيارات الحدود ==================

                dr!MaxLimitForFirstUnite = Val(MaxLimitForFirstUnite.Text)
                dr!MinLimitForFirstUnite = Val(MinLimitForFirstUnite.Text)
                dr!OrderLimitForFirstUnite = Val(OrderLimitForFirstUnite.Text)

                dr!MaxLimitForSecoundUnite = Val(MaxLimitForSecoundUnite.Text)
                dr!MinLimitForSecoundUnite = Val(MinLimitForSecoundUnite.Text)
                dr!OrderLimitForSecoundUnite = Val(OrderLimitForSecoundUnite.Text)

                dr!MaxLimitForThirdUnite = Val(MaxLimitForThirdUnite.Text)
                dr!MinLimitForThirdUnite = Val(MinLimitForThirdUnite.Text)
                dr!OrderLimitForThirdUnite = Val(OrderLimitForThirdUnite.Text)

                If UnitDefault.Checked = True Then dr!UnitDefault = 1
                If UnitDefault2.Checked = True Then dr!UnitDefault = 2
                If UnitDefault3.Checked = True Then dr!UnitDefault = 3
                '=============================== اسعار البيع =====================
                Dim tableName As String = ""
                Dim str1 As String = ""
                Dim flg As Boolean = False
                'If SaleStrategy.SelectedIndex = 0 Then tableName = "ItemNormalPricess"
                'If SaleStrategy.SelectedIndex = 1 Then tableName = "ItemSeasonalPrices"
                'str1 = "select * from " & tableName & " where ItemCode=N'" & itemName.Text.Trim & "'"
                '===============================================================
                If SaleStrategy.SelectedIndex = 0 Then
                    str1 = "select * from ItemNormalPricess where ItemCode=N'" & itemCode.Text.Trim & "'"
                ElseIf SaleStrategy.SelectedIndex = 1 Then
                    str1 = "select * from ItemSeasonalPrices where ItemCode=N'" & itemCode.Text.Trim & "'"
                End If

                Dim adp1 = New SqlClient.SqlDataAdapter(str1, SQLconn)
                Dim ds1 = New DataSet
                adp1.Fill(ds1)
                Dim dt1 As DataTable
                dt1 = ds1.Tables(0)
                Dim dr1 As DataRow
                If dt1.Rows.Count = 0 Then
                    dr1 = dt1.NewRow
                    flg = False
                Else
                    dr1 = dt1.Rows(0)
                    flg = True
                End If
                dr1!itemCode = itemCode.Text
                '--------1
                dr1!WholeSaleForFirstUnit = Val(WholeSaleForFirstUnit.Text)
                dr1!WholeSaleForSecondUnit = Val(WholeSaleForSecondUnit.Text)
                dr1!WholeSaleForThirdUnit = Val(WholeSaleForThirdUnit.Text)
                '--------2
                dr1!HalfWholeSaleForFirstUnit = Val(HalfWholeSaleForFirstUnit.Text)
                dr1!HalfWholeSaleForSecondUnit = Val(HalfWholeSaleForSecondUnit.Text)
                dr1!HalfWholeSaleForThirdUnit = Val(HalfWholeSaleForThirdUnit.Text)
                '--------3
                dr1!DistributorForFirstUnit = Val(DistributorForFirstUnit.Text)
                dr1!DistributorForSecondUnit = Val(DistributorForSecondUnit.Text)
                dr1!DistributorForThirdUnit = Val(DistributorForThirdUnit.Text)
                '--------
                dr1!ExportForFirstUnit = Val(ExportForFirstUnit.Text)
                dr1!ExportForSecondUnit = Val(ExportForSecondUnit.Text)
                dr1!ExportForThirdUnit = Val(ExportForThirdUnit.Text)
                '---------5
                dr1!RetailForFirstUnit = Val(RetailForFirstUnit.Text)
                dr1!RetailForSecondUnit = Val(RetailForSecondUnit.Text)
                dr1!RetailForThirdUnit = Val(RetailForThirdUnit.Text)
                '--------6
                dr1!EndUserForFirstUnit = Val(EndUserForFirstUnit.Text)
                dr1!EndUserForSecondUnit = Val(EndUserForSecondUnit.Text)
                dr1!EndUserForThirdUnit = Val(EndUserForThirdUnit.Text)

                dr1!AManufacturing = AManufacturing.Checked

                If SaleStrategy.SelectedIndex = 1 Then

                    dr1!FromDate = FromDate.Value
                    dr1!ToDate = ToDate.Value
                End If

                If PriceDefault1.Checked = True Then dr1!PriceDefault = 1
                If PriceDefault2.Checked = True Then dr1!PriceDefault = 2
                If PriceDefault3.Checked = True Then dr1!PriceDefault = 3
                If PriceDefault4.Checked = True Then dr1!PriceDefault = 4
                If PriceDefault5.Checked = True Then dr1!PriceDefault = 5
                If PriceDefault6.Checked = True Then dr1!PriceDefault = 6

                If flg = False Then dt1.Rows.Add(dr1)
                Dim cmd1 As New SqlClient.SqlCommandBuilder(adp1)
                adp1.Update(dt1)
                '========================= تشفير الصورة========================
                If OpenFileDialog1.FileName <> "" Then
                    Dim imgByteArrat() As Byte
                    Dim stream As New MemoryStream
                    PicItem.Image.Save(stream, ImageFormat.Jpeg)
                    imgByteArrat = stream.ToArray()
                    stream.Close()
                    dr!PicItem = imgByteArrat
                End If

                '==============================================

                Dim cmd As New SqlClient.SqlCommandBuilder(adp)
                adp.Update(dt)
                BtnNew_Click(Nothing, Nothing)
                MsgBox("تم تعديل بيانات الصنف ف قاعدة البيانات بنجاح", MsgBoxStyle.Information, "رسالة تأكيد")

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "فشل فى عملية التعديل", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
        End Try
        'Catch
        '    MsgBox("فشل فى عملية التعديل ، يرجى اعادة المحاولة لاحقا ", MsgBoxStyle.Critical, "خطأ")
        'End Try
    End Sub

    Private Sub BtnDelete_Click(sender As System.Object, e As System.EventArgs) Handles BtnDelete.Click
        If MsgBox("سوف يتم حذف سجل هذا الصنف وحفظه فى الارشيف , هل تريد الاستمرار ", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "رسالة") = MsgBoxResult.No Then Exit Sub

        Try

            Dim str = "select * from Items where itemCode=N'" & itemCode.Text.Trim & "'"
            Dim adp As New SqlClient.SqlDataAdapter(str, SQLconn)
            Dim ds As New DataSet
            adp.Fill(ds)
            Dim dt = ds.Tables(0)
            If dt.Rows.Count = 0 Then
                MsgBox(" لم يتم العثور على بيانات السجل ", MsgBoxStyle.Exclamation, "رسالة تنبيه")
            Else
                Dim dr = dt.Rows(0)
                'dr.Delete()
                dr!status = False
                Dim cmd As New SqlClient.SqlCommandBuilder(adp)
                adp.Update(dt)
                BtnNew_Click(Nothing, Nothing)
                MsgBox("تم ترحيل بيانات الصنف الى الارشيف بنجاح", MsgBoxStyle.Information, "رسالة تأكيد")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "فشل فى عملية الحذف", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
        End Try
        'Catch
        '    MsgBox("فشل فى عملية الحذف ، يرجى اعادة المحاولة لاحقا ", MsgBoxStyle.Critical, "خطأ")
        'End Try
    End Sub

    Private Sub SaleStrategy_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles SaleStrategy.SelectedIndexChanged
        If SaleStrategy.SelectedIndex = 0 Then
            AManufacturing.Enabled = False
            AManufacturing.Checked = False
        End If
        If SaleStrategy.SelectedIndex = 1 Then
            AManufacturing.Enabled = True
            AManufacturing.Checked = True
        End If

    End Sub

    Private Sub FrmItems_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BtnNew_Click(Nothing, Nothing)
    End Sub

    

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        Dim sql As String = ""
        If TextBox1.Text.Length = 0 Then
            'sql = "select * from Items order by itemName"
            sql = "select * from Items  where status='true' order by itemName"

        Else
            Select Case ComboBox1.SelectedIndex
                'البحث حسب رمز العميل
                Case 0
                    sql = "select * from Items where itemCode like N'" & TextBox1.Text.Trim & "%" & "'" & " order by itemCode "
                    'البحث حسب اسم العميل
                Case 1
                    sql = "select * from Items where itemName like N'" & TextBox1.Text.Trim & "%" & "'" & " order by itemName "
                    'البحث حسب رقم الهاتف
                Case 2
                    sql = "select * from Items where ItemSerial like N'" & TextBox1.Text.Trim & "%" & "'" & " order by ItemSerial "
                Case 3
                    sql = "select * from Items where Size like N'" & TextBox1.Text.Trim & "%" & "'" & " order by Size"
                Case 4
                    sql = "select * from Items  where status='true' order by itemName "
                Case 5
                    sql = "select * from Items  where status='false' order by itemName"
                Case 6
                    sql = "select * from Items order by itemName"
            End Select

        End If

        If Trim(sql) <> "" Then PuFillDataGridView(DataGridView2, sql)
        BtnNew_Click(Nothing, Nothing)
        '========================================
    End Sub

    Private Sub DataGridView2_Click(sender As System.Object, e As System.EventArgs) Handles DataGridView2.Click

        If frmOp = 5 Then
            ShowRecordData(DataGridView2.CurrentRow.Cells(1).Value)

            GroupBox9.Visible = False
            GroupBox1.Visible = True
            GroupBox1.BringToFront()

        End If



        '==============================================================شاشة الاصناف
        If DataGridView2.Rows.Count = Nothing Then Exit Sub

        If frmOp = 10 Then

            For i = 0 To FrmReceiptOfItems.DataGridView1.Rows.Count - 1
                If FrmReceiptOfItems.DataGridView1.Rows(i).Cells(0).Value = DataGridView2.CurrentRow.Cells(1).Value Then
                    MsgBox("هذا الصنف تم ادخالة سابقا لايمكن تكرارة", MsgBoxStyle.Critical, "تنبيه")
                    Exit Sub
                End If
            Next


            FrmReceiptOfItems.DataGridView1.Rows.Add()
            FrmReceiptOfItems.DataGridView1.Rows(FrmReceiptOfItems.DataGridView1.Rows.Count - 1).Cells(0).Value = DataGridView2.CurrentRow.Cells(1).Value
            FrmReceiptOfItems.DataGridView1.Rows(FrmReceiptOfItems.DataGridView1.Rows.Count - 1).Cells(1).Value = DataGridView2.CurrentRow.Cells(2).Value
            ItmCoD = DataGridView2.CurrentRow.Cells(1).Value
            Me.Dispose()

            GoTo eso


        End If

        '==============================================================شاشة الاتلاف


        If DataGridView2.Rows.Count = Nothing Then Exit Sub

        If frmOp = 20 Then

            For i = 0 To FrmDamagedItems.DataGridView1.Rows.Count - 1
                If FrmDamagedItems.DataGridView1.Rows(i).Cells(0).Value = DataGridView2.CurrentRow.Cells(1).Value Then
                    MsgBox("هذا الصنف تم ادخالة سابقا ضمن سند الاتلاف لايمكن تكرارة", MsgBoxStyle.Critical, "تنبيه")
                    Exit Sub
                End If
            Next


            FrmDamagedItems.DataGridView1.Rows.Add()
            FrmDamagedItems.DataGridView1.Rows(FrmDamagedItems.DataGridView1.Rows.Count - 1).Cells(0).Value = DataGridView2.CurrentRow.Cells(1).Value
            FrmDamagedItems.DataGridView1.Rows(FrmDamagedItems.DataGridView1.Rows.Count - 1).Cells(1).Value = DataGridView2.CurrentRow.Cells(2).Value
            ItmCoD = DataGridView2.CurrentRow.Cells(1).Value
            Me.Dispose()

            GoTo eso

        End If

        '==============================================================شاشة المبيعات


        If DataGridView2.Rows.Count = Nothing Then Exit Sub

        If frmOp = 30 Then

            For i = 0 To FrmSalesInvoice.DataGridView1.Rows.Count - 1
                If FrmSalesInvoice.DataGridView1.Rows(i).Cells(0).Value = DataGridView2.CurrentRow.Cells(1).Value Then
                    MsgBox("هذا الصنف تم ادخالة سابقا ضمن سند المبيعات لايمكن تكرارة", MsgBoxStyle.Critical, "تنبيه")
                    Exit Sub
                End If
            Next


            FrmSalesInvoice.DataGridView1.Rows.Add()
            FrmSalesInvoice.DataGridView1.Rows(FrmSalesInvoice.DataGridView1.Rows.Count - 1).Cells(0).Value = DataGridView2.CurrentRow.Cells(1).Value
            FrmSalesInvoice.DataGridView1.Rows(FrmSalesInvoice.DataGridView1.Rows.Count - 1).Cells(1).Value = DataGridView2.CurrentRow.Cells(2).Value
            ItmCoD = DataGridView2.CurrentRow.Cells(1).Value
            Me.Dispose()

            GoTo eso

        End If

        
eso:

    End Sub

    Private Sub BtnSearch_Click(sender As System.Object, e As System.EventArgs) Handles BtnSearch.Click
        frmOp = 5
        ComboBox1.SelectedIndex = 4
        TextBox1_TextChanged(Nothing, Nothing)
        GroupBox9.Visible = True
        GroupBox1.Visible = False
        GroupBox9.BringToFront()
    End Sub

    Private Sub SearchExit_Click(sender As System.Object, e As System.EventArgs) Handles SearchExit.Click
        GroupBox9.Visible = False
        GroupBox1.Visible = True
        GroupBox1.BringToFront()
    End Sub

    Private Sub DataGridView2_RowsAdded(sender As System.Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DataGridView2.RowsAdded
        For I = 0 To DataGridView2.Rows.Count - 1
            DataGridView2.Rows(I).Cells(0).Value = " عرض"
            Dim row As DataGridViewRow = DataGridView2.Rows(I)
            row.Height = 23
        Next
    End Sub

    Sub ShowRecordData(x)
        OpenFileDialog1.FileName = ""
        TabControl1.SelectedIndex = 0
        Dim sql = "select * from Items where itemCode=N'" & x & "'"
        Dim adp = New SqlClient.SqlDataAdapter(sql, SQLconn)
        Dim ds = New DataSet
        adp.Fill(ds)
        Dim dt As DataTable
        dt = ds.Tables(0)
        If dt.Rows.Count = 0 Then
            MsgBox("لم يتم العثور على بيانات السجل", MsgBoxStyle.Exclamation, "رسالة تنبيه")
        Else
            Dim dr = dt.Rows(0)
            On Error Resume Next
            '============================ البيانات الاساسية ========================
            itemCode.Text = dr!itemCode
            itemName.Text = dr!itemName
            ItemSerial.Text = dr!ItemSerial
            ItemSerial2.Text = dr!ItemSerial2
            CategorizationName.Text = dr!CategorizationName
            _Size.Text = dr!Size
            Size1.Text = dr!Size1
            Origin.Text = dr!Origin
            _Location.Text = dr!Location
            Company.Text = dr!Company
            _Color.Text = dr!Color
            Provenance.Text = dr!Provenance
            Quality.Text = dr!Quality
            Model.Text = dr!Model
            adding.Text = dr!adding
            Note.Text = dr!Note
            If IsDBNull(ProductionDate.Text) = False Then ProductionDate.Text = Format(dr!ProductionDate, "yyyy/mm/dd")
            If IsDBNull(ExpaireDate.Text) = False Then ExpaireDate.Text = Format(dr!ExpaireDate, "yyyy/mm/dd")
            SaleStrategy.SelectedIndex = dr!SaleStrategy

            '================================== الوحـــــــدات=================================
            FirstUnit.Text = dr!FirstUnit
            FirstUnitBarcode.Text = dr!FirstUnitBarcode

            SecoundtUnit.Text = dr!SecoundtUnit
            SecoundtUnitBarcode.Text = dr!SecoundtUnitBarcode
            SecoundUnitOperatingConv.Text = dr!SecoundUnitOperatingConv

            ThirdUnit.Text = dr!ThirdUnit
            ThirdtUnitBarcode.Text = dr!ThirdtUnitBarcode
            ThirdUnitOperatingConv.Text = dr!ThirdUnitOperatingConv
            itemQuantity.Text = dr!itemQuantity
            '====================================== خيارات الحدود ==================

            MaxLimitForFirstUnite.Text = dr!MaxLimitForFirstUnite
            MinLimitForFirstUnite.Text = dr!MinLimitForFirstUnite
            OrderLimitForFirstUnite.Text = dr!OrderLimitForFirstUnite

            MaxLimitForSecoundUnite.Text = dr!MaxLimitForSecoundUnite
            MinLimitForSecoundUnite.Text = dr!MinLimitForSecoundUnite
            OrderLimitForSecoundUnite.Text = dr!OrderLimitForSecoundUnite

            MaxLimitForThirdUnite.Text = dr!MaxLimitForThirdUnite
            MinLimitForThirdUnite.Text = dr!MinLimitForThirdUnite
            OrderLimitForThirdUnite.Text = dr!OrderLimitForThirdUnite

            If dr!UnitDefault = 1 Then UnitDefault.Checked = True
            If dr!UnitDefault = 2 Then UnitDefault2.Checked = True
            If dr!UnitDefault = 3 Then UnitDefault3.Checked = True

            '=============================== اسعار البيع =====================
            Dim tableName As String = ""
            Dim str1 As String = ""
            Dim flg As Boolean = False
            'If SaleStrategy.SelectedIndex = 0 Then tableName = "ItemNormalPricess"
            'If SaleStrategy.SelectedIndex = 1 Then tableName = "ItemSeasonalPrices"
            'str1 = "select * from " & tableName & " where ItemCode=N'" & itemName.Text.Trim & "'"
            '===============================================================
            If SaleStrategy.SelectedIndex = 0 Then
                str1 = "select * from ItemNormalPricess where ItemCode=N'" & itemCode.Text.Trim & "'"
            ElseIf SaleStrategy.SelectedIndex = 1 Then
                str1 = "select * from ItemSeasonalPrices where ItemCode=N'" & itemCode.Text.Trim & "'"
            End If

            Dim Adp1 = New SqlClient.SqlDataAdapter(str1, SQLconn)
            Dim Ds1 = New DataSet
            Adp1.Fill(Ds1)
            Dim Dt1 As DataTable
            Dt1 = Ds1.Tables(0)
            If Dt1.Rows.Count > 0 Then
                Dim dr1 = Dt1.Rows(0)

                '--------1
                WholeSaleForFirstUnit.Text = dr1!WholeSaleForFirstUnit
                WholeSaleForSecondUnit.Text = dr1!WholeSaleForSecondUnit
                WholeSaleForThirdUnit.Text = dr1!WholeSaleForThirdUnit
                '--------2
                HalfWholeSaleForFirstUnit.Text = dr1!HalfWholeSaleForFirstUnit
                HalfWholeSaleForSecondUnit.Text = dr1!HalfWholeSaleForSecondUnit
                HalfWholeSaleForThirdUnit.Text = dr1!HalfWholeSaleForThirdUnit
                '--------3
                DistributorForFirstUnit.Text = dr1!DistributorForFirstUnit
                DistributorForSecondUnit.Text = dr1!DistributorForSecondUnit
                DistributorForThirdUnit.Text = dr1!DistributorForThirdUnit
                '--------4
                ExportForFirstUnit.Text = dr1!ExportForFirstUnit
                ExportForSecondUnit.Text = dr1!ExportForSecondUnit
                ExportForThirdUnit.Text = dr1!ExportForThirdUnit
                '---------5
                RetailForFirstUnit.Text = dr1!RetailForFirstUnit
                RetailForSecondUnit.Text = dr1!RetailForSecondUnit
                RetailForThirdUnit.Text = dr1!RetailForThirdUnit
                '--------6
                EndUserForFirstUnit.Text = dr1!EndUserForFirstUnit
                EndUserForSecondUnit.Text = dr1!EndUserForSecondUnit
                EndUserForThirdUnit.Text = dr1!EndUserForThirdUnit

                AManufacturing.Checked = dr1!AManufacturing

                If SaleStrategy.SelectedIndex = 1 Then

                    FromDate.Value = dr1!FromDate
                    ToDate.Value = dr1!ToDate
                End If

                If dr1!PriceDefault = 1 Then PriceDefault1.Checked = True
                If dr1!PriceDefault = 2 Then PriceDefault2.Checked = True
                If dr1!PriceDefault = 3 Then PriceDefault3.Checked = True
                If dr1!PriceDefault = 4 Then PriceDefault4.Checked = True
                If dr1!PriceDefault = 5 Then PriceDefault5.Checked = True
                If dr1!PriceDefault = 6 Then PriceDefault6.Checked = True

            End If
            '========================= فك تشفير الصورة========================
            If IsDBNull(dr!PicItem) = False Then
                Dim imgByteArray() As Byte
                imgByteArray = CType(dr!PicItem, Byte())
                Dim stream As New MemoryStream(imgByteArray)
                Dim bmp As New Bitmap(stream)
                PicItem.Image = Image.FromStream(stream)
                stream.Close()
            End If

            BtnSave.Enabled = False
            BtnEdit.Enabled = True
            BtnDelete.Enabled = True
        End If
    End Sub



    Private Sub DataGridView2_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub
    Dim ItmCoD As String
    Private Sub FrmItems_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        'FrmReceiptOfItems.GetItemUnits(ItmCoD)
        If Trim(ItmCoD) = "" Then Exit Sub
        Select Case frmOp
            Case 5
                ShowRecordData(DataGridView2.CurrentRow.Cells(1).Value)

                GroupBox9.Visible = False
                GroupBox1.Visible = True
                GroupBox1.BringToFront()

            Case 10

                GetItemUnits(FrmReceiptOfItems.DataGridView1, ItmCoD)

            Case 20
                GetItemUnits(FrmDamagedItems.DataGridView1, ItmCoD)

            Case 30
                Dim x = Split(GetDEf_Unit_Price(ItmCoD), "|")
                FrmSalesInvoice.DataGridView1.Rows(FrmSalesInvoice.DataGridView1.Rows.Count - 1).Cells(2).Value = x(0)
                FrmSalesInvoice.DataGridView1.Rows(FrmSalesInvoice.DataGridView1.Rows.Count - 1).Cells(3).Value = x(1)
                FrmSalesInvoice.DataGridView1.Rows(FrmSalesInvoice.DataGridView1.Rows.Count - 1).Cells(4).Value = 1
                FrmSalesInvoice.DataGridView1.Rows(FrmSalesInvoice.DataGridView1.Rows.Count - 1).Cells(6).Value = Format(x(1) * 1, "0.000")
                FrmSalesInvoice.DataGridView1.Rows(FrmSalesInvoice.DataGridView1.Rows.Count - 1).Cells(9).Value = x(2)
        End Select
    End Sub

    Private Sub BtnEx_Click(sender As System.Object, e As System.EventArgs) Handles BtnEx.Click
        Close()

    End Sub

    Private Sub BtnExit_Click(sender As System.Object, e As System.EventArgs) Handles BtnExit.Click
        Close()

    End Sub
End Class