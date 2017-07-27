Module ArabicTxt


    Public Function IsLaM(ByVal IsLaM1 As Decimal, ByVal IsLaM2 As String) As String
        On Error Resume Next
        Dim VPS As Decimal = 0
        Dim V As Decimal = 0
        Dim WORDINTEGER As String = ""
        Dim LE As String = ""
        Dim P As String = ""
        Dim PS As String = ""
        IsLaM = ""
        Dim POUNDS As String = ""
        Dim WORDPS As String = ""
        Dim DOLLAR As String = ""
        Dim SENT As String = ""
        Dim SENTS As String = ""
        Dim TON As String = ""
        Dim KG As String = ""
        Dim KGS As String = ""
        Select Case IsLaM2

            Case "Egypt"
                LE = " جنيهاً "
                P = " قرشأً "
                PS = " قروش "
                POUNDS = " جنيهات "
                V = Int(Math.Abs(IsLaM1))
                VPS = Val(Right(Format(IsLaM1, "000000000000.00"), 2))
                WORDINTEGER = AmountWord(V)
                WORDPS = AmountWord(VPS)
                If WORDINTEGER <> "" And (VPS <= 2) Then IsLaM = WORDINTEGER & LE & " و " & WORDPS & P & "فقط لاغير "
                If WORDINTEGER <> "" And (VPS >= 3 And VPS <= 9) Then IsLaM = WORDINTEGER & LE & " و " & WORDPS & PS & "فقط لاغير "
                If WORDINTEGER <> "" And (VPS > 9) Then IsLaM = WORDINTEGER & LE & " و " & WORDPS & P & "فقط لاغير "
                If WORDINTEGER = "" And (VPS <= 2) Then IsLaM = WORDPS & P & "فقط لاغير "
                If WORDINTEGER = "" And (VPS >= 3 And VPS <= 9) Then IsLaM = WORDPS & PS & "فقط لاغير "
                If WORDINTEGER = "" And VPS > 9 Then IsLaM = WORDPS & P & "فقط لاغير "
                If WORDINTEGER = "" And VPS = 0 Then IsLaM = ""
                If WORDINTEGER <> "" And VPS = 0 Then IsLaM = WORDINTEGER & LE & "فقط لاغير "


            Case "Libya"
                LE = " دينـار "
                P = " درهم "
                PS = " دراهم "
                POUNDS = " دنانير "
                V = Int(Math.Abs(IsLaM1))
                VPS = Val(Right(Format(IsLaM1, "000000000000.00"), 2))
                WORDINTEGER = AmountWord(V)
                WORDPS = AmountWord(VPS)
                If WORDINTEGER <> "" And (VPS <= 2) Then IsLaM = WORDINTEGER & LE & " و " & WORDPS & P & "فقط لاغير "
                If WORDINTEGER <> "" And (VPS >= 3 And VPS <= 9) Then IsLaM = WORDINTEGER & LE & " و " & WORDPS & PS & "فقط لاغير "
                If WORDINTEGER <> "" And (VPS > 9) Then IsLaM = WORDINTEGER & LE & " و " & WORDPS & P & "فقط لاغير "
                If WORDINTEGER = "" And (VPS <= 2) Then IsLaM = WORDPS & P & "فقط لاغير "
                If WORDINTEGER = "" And (VPS >= 3 And VPS <= 9) Then IsLaM = WORDPS & PS & "فقط لاغير "
                If WORDINTEGER = "" And VPS > 9 Then IsLaM = WORDPS & P & "فقط لاغير "
                If WORDINTEGER = "" And VPS = 0 Then IsLaM = ""
                If WORDINTEGER <> "" And VPS = 0 Then IsLaM = WORDINTEGER & LE & "فقط لاغير "
            Case "USA"
                DOLLAR = " دولار "
                SENT = " سنتاً "
                SENTS = "سنتات"
                V = Int(System.Math.Abs(IsLaM1))
                VPS = Val(Right(Format(IsLaM1, "000000000000.00"), 2))
                WORDINTEGER = AmountWord(V)
                WORDPS = AmountWord(VPS)
                If WORDINTEGER <> "" And (VPS <= 2) Then IsLaM = WORDINTEGER & DOLLAR & " و " & WORDPS & SENT & "فقط لاغير "
                If WORDINTEGER <> "" And (VPS >= 3 And VPS <= 9) Then IsLaM = WORDINTEGER & DOLLAR & " و " & WORDPS & " " & SENTS & " " & "فقط لاغير "
                If WORDINTEGER <> "" And (VPS > 9) Then IsLaM = WORDINTEGER & DOLLAR & " و " & WORDPS & SENT & "فقط لاغير "
                If WORDINTEGER = "" And (VPS <= 2) Then IsLaM = WORDPS & SENT & "فقط لاغير "
                If WORDINTEGER = "" And (VPS >= 3 And VPS <= 9) Then IsLaM = WORDPS & " " & SENTS & " " & "فقط لاغير "
                If WORDINTEGER = "" And VPS > 9 Then IsLaM = WORDPS & SENT & "فقط لاغير "
                If WORDINTEGER = "" And VPS = 0 Then IsLaM = ""
                If WORDINTEGER <> "" And VPS = 0 Then IsLaM = WORDINTEGER & DOLLAR & "فقط لاغير "
            Case "WEIGHT"
                TON = " طن "
                KG = " كيلو جرام "
                KGS = "كيلو جرامات"
                V = Int(Math.Abs(IsLaM1))
                VPS = Val(Right(Format(IsLaM1, "000000000000.000"), 3))
                WORDINTEGER = AmountWord(V)
                WORDPS = AmountWord(VPS)
                If WORDINTEGER <> "" And (VPS <= 2) Then IsLaM = WORDINTEGER & TON & " و " & WORDPS & KG & "فقط لاغير "
                If WORDINTEGER <> "" And (VPS >= 3 And VPS <= 9) Then IsLaM = WORDINTEGER & TON & " و " & WORDPS & KGS & "فقط لاغير "
                If WORDINTEGER <> "" And (VPS > 9) Then IsLaM = WORDINTEGER & TON & " و " & WORDPS & KG & "فقط لاغير "
                If WORDINTEGER = "" And (VPS <= 2) Then IsLaM = WORDPS & KG & "فقط لاغير "
                If WORDINTEGER = "" And (VPS >= 3 And VPS <= 9) Then IsLaM = WORDPS & KGS & "فقط لاغير "
                If WORDINTEGER = "" And VPS > 9 Then IsLaM = WORDPS & KG & "فقط لاغير "
                If WORDINTEGER = "" And VPS = 0 Then IsLaM = ""
                If WORDINTEGER <> "" And VPS = 0 Then IsLaM = WORDINTEGER & TON & "فقط لاغير "
        End Select
    End Function


    Private Function AmountWord(ByVal AMOUNT As Decimal) As String
        On Error Resume Next
        Dim n As Decimal = 0
        Dim C1 As Decimal = 0
        Dim C2 As Decimal = 0
        Dim C3 As Decimal = 0
        Dim C4 As Decimal = 0
        Dim C5 As Decimal = 0
        Dim C6 As Decimal = 0
        Dim S1 As String = ""
        Dim S2 As String = ""
        Dim S3 As String = ""
        Dim S4 As String = ""
        Dim S5 As String = ""
        Dim S6 As String = ""
        Dim C As String = ""
        n = Int(AMOUNT)
        C = Format(n, "000000000000")
        C1 = Val(Mid(C, 12, 1))
        Select Case C1
            Case Is = 1 : S1 = "واحد"
            Case Is = 2 : S1 = "اثنان"
            Case Is = 3 : S1 = "ثلاثة"
            Case Is = 4 : S1 = "اربعة"
            Case Is = 5 : S1 = "خمسة"
            Case Is = 6 : S1 = "ستة"
            Case Is = 7 : S1 = "سبعة"
            Case Is = 8 : S1 = "ثمانية"
            Case Is = 9 : S1 = "تسعة"
        End Select

        C2 = Val(Mid(C, 11, 1))
        Select Case C2
            Case Is = 1 : S2 = "عشر"
            Case Is = 2 : S2 = "عشرون"
            Case Is = 3 : S2 = "ثلاثون"
            Case Is = 4 : S2 = "اربعون"
            Case Is = 5 : S2 = "خمسون"
            Case Is = 6 : S2 = "ستون"
            Case Is = 7 : S2 = "سبعون"
            Case Is = 8 : S2 = "ثمانون"
            Case Is = 9 : S2 = "تسعون"
        End Select

        If S1 <> "" And C2 > 1 Then S2 = S1 + " و" + S2
        If S2 = "" Then S2 = S1
        If C1 = 0 And C2 = 1 Then S2 = S2 + "ة"
        If C1 = 1 And C2 = 1 Then S2 = "احدى عشر"
        If C1 = 2 And C2 = 1 Then S2 = "اثنى عشر"
        If C1 > 2 And C2 = 1 Then S2 = S1 + " " + S2
        C3 = Val(Mid(C, 10, 1))
        Select Case C3
            Case Is = 1 : S3 = "مائة"
            Case Is = 2 : S3 = "مئتان"
            Case Is > 2 : S3 = Left(AmountWord(C3), Len(AmountWord(C3)) - 1) + "مائة"
        End Select
        If S3 <> "" And S2 <> "" Then S3 = S3 + " و" + S2
        If S3 = "" Then S3 = S2

        C4 = Val(Mid(C, 7, 3))
        Select Case C4
            Case Is = 1 : S4 = "الف"
            Case Is = 2 : S4 = "الفان"
            Case 3 To 10 : S4 = AmountWord(C4) + " آلاف"
            Case Is > 10 : S4 = AmountWord(C4) + " الف"
        End Select
        If S4 <> "" And S3 <> "" Then S4 = S4 + " و" + S3
        If S4 = "" Then S4 = S3
        C5 = Val(Mid(C, 4, 3))
        Select Case C5
            Case Is = 1 : S5 = "مليون"
            Case Is = 2 : S5 = "مليونان"
            Case 3 To 10 : S5 = AmountWord(C5) + " ملايين"
            Case Is > 10 : S5 = AmountWord(C5) + " مليون"
        End Select
        If S5 <> "" And S4 <> "" Then S5 = S5 + " و" + S4
        If S5 = "" Then S5 = S4

        C6 = Val(Mid(C, 1, 3))

        Select Case C6
            Case Is = 1 : S6 = "مليار"
            Case Is = 2 : S6 = "ملياران"
            Case Is > 2 : S6 = AmountWord(C6) + " مليار"
        End Select
        If S6 <> "" And S5 <> "" Then S6 = S6 + " و" + S5
        If S6 = "" Then S6 = S5
        AmountWord = S6
    End Function

    Public Function MydateWord(ByVal MYDATE As Date) As String
        On Error Resume Next
        Dim n As Integer = 0
        Dim C1 As Decimal = 0
        Dim C2 As Decimal = 0
        Dim C3 As Decimal = 0
        Dim S1 As String = ""
        Dim S2 As String = ""
        Dim C As String = ""
        MydateWord = ""
        C = Format(MYDATE, "dd-mm-yyyy")
        C1 = MYDATE.Day
        C2 = MYDATE.Month
        C3 = MYDATE.Year
        Select Case C1
            Case Is = 1 : S1 = "الاول"
            Case Is = 2 : S1 = "الثانى"
            Case Is = 3 : S1 = "الثالث"
            Case Is = 4 : S1 = "الرابع"
            Case Is = 5 : S1 = "الخامس"
            Case Is = 6 : S1 = "السادس"
            Case Is = 7 : S1 = "السابع"
            Case Is = 8 : S1 = "الثامن"
            Case Is = 9 : S1 = "التاسع"
            Case Is = 10 : S1 = "العاشر"
            Case Is = 11 : S1 = "الحادى عشر"
            Case Is = 12 : S1 = "الثانى عشر"
            Case Is = 13 : S1 = "الثالث عشر"
            Case Is = 14 : S1 = "الرابع عشر"
            Case Is = 15 : S1 = "الخامس عشر"
            Case Is = 16 : S1 = "السادس عشر"
            Case Is = 17 : S1 = "السابع عشر"
            Case Is = 18 : S1 = "الثامن عشر"
            Case Is = 19 : S1 = "التاسع عشر"
            Case Is = 20 : S1 = "العشرون"
            Case Is = 21 : S1 = "الواحد والعشرون"
            Case Is = 22 : S1 = " الثانى والعشرون"
            Case Is = 23 : S1 = "الثالث والعشرون"
            Case Is = 24 : S1 = " الرابع والعشرون"
            Case Is = 25 : S1 = " الخامس والعشرون"
            Case Is = 26 : S1 = "السادس والعشرون"
            Case Is = 27 : S1 = "السابع والعشرون"
            Case Is = 28 : S1 = "الثامن والعشرون"
            Case Is = 29 : S1 = "التاسع والعشرون"
            Case Is = 30 : S1 = "الثلاثون"
            Case Is = 31 : S1 = "الواحد والثلاثون"
        End Select

        Select Case C2
            Case Is = 1 : S2 = "يناير"
            Case Is = 2 : S2 = "فبراير"
            Case Is = 3 : S2 = "مارس"
            Case Is = 4 : S2 = "ابريل"
            Case Is = 5 : S2 = "مايو"
            Case Is = 6 : S2 = "يونية"
            Case Is = 7 : S2 = "يوليو"
            Case Is = 8 : S2 = "اغسطس"
            Case Is = 9 : S2 = "سبتمبر"
            Case Is = 10 : S2 = "اكتوبر"
            Case Is = 11 : S2 = "نوفمبر"
            Case Is = 12 : S2 = "ديسمبر"
        End Select
        MydateWord = Format(MYDATE, "dddd") & " الموافق " & S1 & " من  شهر " & S2 & " سنة " & AmountWord(CDec(C3)) & " ميلادية "
    End Function
    Public Function MytimeWord(ByVal MYTIME As DateTime) As String
        On Error Resume Next
        Dim n As Integer = 0
        Dim C1 As Decimal = 0
        Dim C2 As Decimal = 0
        Dim C3 As Decimal = 0
        Dim C4 As String = ""
        Dim S1 As String = ""
        Dim S2 As String = ""
        Dim S3 As String = ""
        Dim S4 As String = ""
        Dim S5 As String = ""
        Dim C As DateTime
        MytimeWord = ""
        C = Format(MYTIME, "hh:mm:ss tt")
        C1 = Format(C, "ss")
        C2 = Format(C, "mm")
        C3 = Format(C, "hh")
        C4 = Format(C, "tt")
        Select Case C4
            Case "ص" : S4 = "صباحاَ"
            Case "م" : S4 = "مساءً"
            Case "AM" : S4 = "صباحاَ"
            Case "PM" : S4 = "مساءً"
        End Select
        Select Case C1
            Case Is = 0 : S3 = ""
            Case Is = 1 : S3 = " ثانية واحدة "
            Case Is = 2 : S3 = " ثانيتان"
            Case 3 To 10 : S3 = AmountWord(C1) + " ثوان"
            Case Is > 10 : S3 = AmountWord(C1) + " ثانية"
        End Select
        Select Case C2
            Case Is = 0 : S1 = ""
            Case Is = 1 : S1 = " دقيقة واحدة "
            Case Is = 2 : S1 = " دقيقتان "
            Case 3 To 10 : S1 = AmountWord(C2) + " دقائق "
            Case Is > 10 : S1 = AmountWord(C2) + " دقيقة "
        End Select
        If S1 <> "" And S3 <> "" Then S5 = S1 + " و" + S3
        If S1 = "" Then S5 = S3
        Select Case C3
            Case Is = 0 : S2 = ""
            Case Is = 1 : S2 = "الواحدة"
            Case Is = 2 : S2 = "الثانية"
            Case Is = 3 : S2 = "الثالثة"
            Case Is = 4 : S2 = "الرابعة"
            Case Is = 5 : S2 = "الخامسة"
            Case Is = 6 : S2 = "السادسة"
            Case Is = 7 : S2 = "السابعة"
            Case Is = 8 : S2 = "الثامنة"
            Case Is = 9 : S2 = "التاسعة"
            Case Is = 10 : S2 = "العاشرة"
            Case Is = 11 : S2 = "الحادية عشر"
            Case Is = 12 : S2 = "الثانية عشر"
        End Select
        If S2 <> "" And S1 <> "" And S3 <> "" Then S5 = S2 + " و" + S1 + " و" + S3
        If S2 <> "" And S1 <> "" And S3 = "" Then S5 = S2 + " و" + S1
        If S2 <> "" And S1 = "" And S3 <> "" Then S5 = S2 + " و" + S3
        If S2 <> "" And S1 = "" And S3 = "" Then S5 = S2
        MytimeWord = " الساعة " & S5 & " " & S4
    End Function


    Public Sub MYSHUTDOWN(ByVal OPERATION As Byte)
        On Error Resume Next
        Dim resault As Integer
        Select Case OPERATION
            Case 0
                resault = MessageBox.Show("هل تريد غلق الجهاز", "اغلاق الجهاز ", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    Shell("shutdown -s -f -t 0")
                Else
                    Exit Sub
                End If
            Case 1
                resault = MessageBox.Show("هل تريد اعادة تشغيل الويندز ", "اعادة تشغيل الويندز ", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    Shell("shutdown -r -f -t 0")
                Else
                    Exit Sub
                End If
            Case 2
                resault = MessageBox.Show("هل تريد عمل Log Off ", "Log Off ", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    Shell("shutdown -l -f -t 0")
                Else
                    Exit Sub
                End If
        End Select
    End Sub



End Module
