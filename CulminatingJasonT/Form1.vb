Imports System.Drawing.Text
Public Class Form1
#Region "About the Game."
    'Kirby Dreamland: Stage 1

    'By: Jason Tran
    'Project Start Date: November 26 2018
    'Project Finish Date: January 28 2018

    'About -----------------------------------
    'This is the closest recreation of Kirby's
    'first appearance from a game that can be 
    'played on the gameboy, April 27, 1992. 
    'Due to the deadline, I was only able to 
    'finish the first stage of the game, with 
    '2 levels and minor changes.

    'Controls --------------------------------
    'Up Arrow - Fly
    'Left Arrow - Move Left
    'Right Arrow - Move Right
    'Down Arrow - Eat
    'A - Jump
    'S - Attack

    'Features --------------------------------
    '-Character Animations
    '-Enemy Animations
    '-Moving Background
    '-Gravity
    '-Jump
    '-Character Move
    '-Fly
    '-Fat
    '-Platforms
    '-Walls

    '-Enemy Arrays
    '-Boss Attack Arrays
    '-Boss Attack has random velocities

    '-Heath Bar
    '-Enemies
    '-Air Attack
    '-Shoot Attack
    '-Consume
    '-Boss AI
    '-Burst Attack
    '-Reload Attack
    '-Apple Drop
    '-Random Apple Location
    '-Enemy AI
    '-Damage

    '-Start Screen
    '-End Screen
    '-Win Screen
    '-Music
    '-Custom Font
    '-Score System
#End Region

#Region "Start Variables"
    'Font Variable -------------------------------------------------------------------------------------------------------------------------
    Dim pfc As PrivateFontCollection = New PrivateFontCollection

    'Start Up/Music Variables --------------------------------------------------------------------------------------------------------------
    Dim screen As Integer = 0
    Dim title As Image = My.Resources.Title

    Dim wp As New WMPLib.WindowsMediaPlayer

#End Region
#Region "Map Variables"

    'Rectangles ---------------------------------------------------------------------------------------------------------------------------
    Dim b1 As Rectangle
    Dim b2 As Rectangle
    Dim b3 As Rectangle
    Dim b4 As Rectangle
    Dim b5 As Rectangle
    Dim b6 As Rectangle
    Dim b7 As Rectangle

    Dim b8 As Rectangle
    Dim b9 As Rectangle
    Dim b10 As Rectangle
    Dim b11 As Rectangle
    Dim b12 As Rectangle
    Dim b13 As Rectangle
    Dim b14 As Rectangle
    Dim b15 As Rectangle

    Dim r1 As Rectangle
    Dim r2 As Rectangle
    Dim r3 As Rectangle
    Dim r4 As Rectangle
    Dim r5 As Rectangle
    Dim r6 As Rectangle
    Dim r7 As Rectangle
    Dim r8 As Rectangle

    Dim i1 As Rectangle

    'Rectangle Position ---------------------------------------------------------------------------------------------------------------------
    Dim RecPosX As Integer
    Dim RecPosY As Integer

#End Region
#Region "Stage 1 Variables"

    'Random ---------------------------------------------------------------------------------------------------------------------------------
    Dim rnd As New Random

    'Game -----------------------------------------------------------------------------------------------------------------------------------
    Dim LiveImg As Image = My.Resources.Lives
    Dim ScoreImg As Image = My.Resources.score
    Dim lives As Integer = 6
    Dim score As Integer

    'Enemy Arrays ---------------------------------------------------------------------------------------------------------------------------
    Dim ac As Integer
    Dim max As Integer = 20
    Dim create As Integer = 0

    'ENEMY VARIABLES ------------------------------------------------------------------------------------------------------------------------
    'Enemy Animation ------------------------------------------------------------------------------------------------------------------------
    Dim eSheet1 As Image = My.Resources.Enemy1
    Dim eSheet2 As Image = My.Resources.Enemy2
    Dim eSheet3 As Image = My.Resources.Enemy3
    Dim eSheet4 As Image = My.Resources.Enemy4

    Dim eSheet1b As Image = My.Resources.Enemy1b
    Dim eSheet2b As Image = My.Resources.Enemy2b
    Dim eSheet3b As Image = My.Resources.Enemy3b
    Dim eSheet4b As Image = My.Resources.Enemy4b

    Dim ecount As Integer

    'Enemy RNG ------------------------------------------------------------------------------------------------------------------------------
    Dim eRNG As Integer
    Dim eType(max) As Integer

    'Postition/Velocities -------------------------------------------------------------------------------------------------------------------
    Dim ePosX(max) As Integer
    Dim ePosY(max) As Integer

    Dim eVelX(max) As Integer
    Dim eVelY(max) As Integer

    Dim eDir(max) As Boolean

    'Enemy Rectangles ------------------------------------------------------------------------------------------------------------------------
    Dim rEnemy(max) As Rectangle

    Dim eRow(max) As Integer
    Dim eCol(max) As Integer
    Dim eTRows(max) As Integer
    Dim eTCols(max) As Integer
    Dim eWidth(max) As Integer
    Dim eHeight(max) As Integer

    'KIRBY VARIABLES -------------------------------------------------------------------------------------------------------------------------
    'Spritesheets ----------------------------------------------------------------------------------------------------------------------------
    Dim kSheet As Image = My.Resources.kSheet
    Dim kFloat As Image = My.Resources.kFly
    Dim kFloat2 As Image = My.Resources.kFly2
    Dim kAA As Image = My.Resources.AirAttack
    Dim kAA2 As Image = My.Resources.AirAttack2
    Dim kBig As Image = My.Resources.kBig
    Dim kBig1 As Image = My.Resources.kBig1
    Dim kBig2 As Image = My.Resources.kBig2
    Dim kBig3 As Image = My.Resources.kBig3
    Dim kBig4 As Image = My.Resources.kBig4
    Dim kBig5 As Image = My.Resources.kBig5
    Dim kFA As Image = My.Resources.FatAttack

    'Jump -----------------------------------------------------------------------------------------------------------------------------------
    Dim g As Double = 9.8
    Dim t As Double = 0
    Dim v2 As Double
    Dim v1 As Double = -25

    'Postition/Velocities --------------------------------------------------------------------------------------------------------------------
    Dim kPosX As Integer
    Dim kPosY As Integer
    Dim kVelY As Integer = 5
    Dim kVelX As Integer = 4

    'Animation -------------------------------------------------------------------------------------------------------------------------------
    Dim kNorm As Boolean = True
    Dim kFace As Boolean = True
    Dim kCount As Integer
    Dim kRow As Integer
    Dim kCol As Integer
    Dim kTRows As Integer
    Dim kTCols As Integer
    Dim kWidth As Integer
    Dim kHeight As Integer

    'Kirby Rectangles ------------------------------------------------------------------------------------------------------------------------
    Dim rKirby As Rectangle
    Dim rDetect As Rectangle
    Dim rAtk As Rectangle
    Dim rSuck As Rectangle

    'Actions ---------------------------------------------------------------------------------------------------------------------------------
    Dim kRight As Boolean
    Dim kLeft As Boolean
    Dim kDown As Boolean
    Dim kUp As Boolean
    Dim kJump As Boolean
    Dim kWalk As Boolean
    Dim kFly As Boolean
    Dim kPreFly As Boolean = True
    Dim kStart As Boolean
    Dim kFall As Boolean = False
    Dim kOn As Boolean = False
    Dim kFlyAtk As Boolean = False
    Dim kMidA As Boolean = False
    Dim kfat As Boolean = False
    Dim kSuck As Boolean = False
    Dim kRevert As Boolean = False
    Dim kHold As Boolean = False
    Dim KConsume As Boolean = False
    Dim kShoot As Boolean = False
    Dim kLand As Boolean = False
    Dim count As Integer

    'Attack -----------------------------------------------------------------------------------------------------------------------------------
    Dim kAtkDis As Integer
    Dim kFirstX As Integer
    Dim kAirAtk As Boolean
    Dim kAtkVel As Integer
    Dim kAtkDir As Boolean

    'Stage 1 Variables ------------------------------------------------------------------------------------------------------------------------
    Dim BGPosX As Integer = 0
    Dim BGPosY As Integer = 0

    Dim BG1 As Image = My.Resources.B1
    Dim BG2 As Image = My.Resources.B2
    Dim BG3 As Image = My.Resources.B3
    Dim BG4 As Image = My.Resources.B4
    Dim BG5 As Image = My.Resources.B5
    Dim BG6 As Image = My.Resources.B6
    Dim BG7 As Image = My.Resources.B7
    Dim BG8 As Image = My.Resources.B8
    Dim BG9 As Image = My.Resources.B9

    'Stage 2 Variables ------------------------------------------------------------------------------------------------------------------------
    Dim BG10 As Image = My.Resources.B10
    Dim BG11 As Image = My.Resources.B11

#End Region
#Region "Boss Battle Variables"

    'Boss Attack Arrays -----------------------------------------------------------------------------------------------------------------------
    Dim tc As Integer
    Dim tMax As Integer = 2
    Dim tCreate As Integer = 0

    'Boss Sprites -----------------------------------------------------------------------------------------------------------------------------
    Dim apple As Image = My.Resources.Apple
    Dim treeFace1 As Image = My.Resources.TreeFace1
    Dim treeFace2 As Image = My.Resources.TreeFaceAtk
    Dim tAtk As Image = My.Resources.TreeAtk

    Dim tFace As Integer = 1

    Dim tWidth(tMax) As Integer
    Dim tHeight(tMax) As Integer

    'Boss Rectangle ---------------------------------------------------------------------------------------------------------------------------
    Dim rTree As Rectangle
    Dim rTFace As Rectangle
    Dim rTreeAtk(tMax) As Rectangle
    Dim rApple As Rectangle

    'Attack Variables -------------------------------------------------------------------------------------------------------------------------
    Dim tPosX(tMax) As Integer
    Dim tPosY(tMax) As Integer

    Dim tVelX(tMax) As Integer
    Dim tVelY(tMax) As Integer

    Dim tBurst As Boolean = False
    Dim tAtkTick As Boolean = False
    Dim tAtkTime As Integer
    Dim tAtkReload As Boolean = True
    Dim tLives As Integer = 3

    'Apple Variables --------------------------------------------------------------------------------------------------------------------------
    Dim AppleSpawn As Boolean = False
    Dim aVelY As Integer = 4
    Dim aVelx As Integer
    Dim aPosX As Integer
    Dim aPosY As Integer

#End Region
#Region "End Variables"

    'End Screen --------------------------------------------------------------------------------------------------------------------------------
    Dim _end As Image = My.Resources._end
    Dim win As Image = My.Resources.win

    'Rectangle ---------------------------------------------------------------------------------------------------------------------------------
    Dim rblock As New Rectangle

    'If Winner ---------------------------------------------------------------------------------------------------------------------------------
    Dim Winner As Boolean

#End Region

#Region "Set Events"
    Private Sub AppleDrop()

        If screen = 2 And RecPosY <= -1170 Then
            'Apple Location --------------------------------------------------------------------------------------------------------------------
            aPosX = rnd.Next(100, 300)
            aPosY = -100

            'Velocity/Rectangle ----------------------------------------------------------------------------------------------------------------
            aVelx = 0
            rApple = New Rectangle(aPosX, aPosY, apple.Width, apple.Height)
        End If

    End Sub
    Private Sub BossAttack()

        If screen = 2 And RecPosY <= -1170 Then
            'Boss Attack Array (Attack when reload tick is false) -------------------------------------------------------------------------------
            If tCreate <= tMax And tAtkTick = False Then
                tCreate += 1

                tFace = 2

                tVelX(tc) = rnd.Next(-10, -5)
                tVelY(tc) = rnd.Next(-3, 3)

                rTreeAtk(tc) = New Rectangle(510, 320, 60, 54)
                tc += 1

                'If reload is true, dont attack, spawn apples, atk tick is set once. ------------------------------------------------------------
            ElseIf tAtkReload = True Then
                tFace = 1
                tAtkTick = True
                tAtkTime = 5
                AppleSpawn = True
                AppleDrop()
                tAtkReload = False
            End If
        End If

    End Sub
    Private Sub SpawnEnemy()

        'Spawn Enemy ---------------------------------------------------------------------------------------------------------------------------
        If create <= max Then
            create += 1

            'Select Which Type of Enemy --------------------------------------------------------------------------------------------------------
            If eType(ac) = 1 Then
                eDir(max) = True

                eTCols(ac) = 2
                eTRows(ac) = 1
                eWidth(ac) = eSheet1.Width / eTCols(ac)
                eHeight(ac) = eSheet1.Height / eTRows(ac)

                rEnemy(ac) = New Rectangle(ePosX(ac), ePosY(ac), eWidth(ac), eHeight(ac))

            ElseIf eType(ac) = 2 Then
                eDir(max) = True

                eTCols(ac) = 2
                eTRows(ac) = 1
                eWidth(ac) = eSheet2.Width / eTCols(ac)
                eHeight(ac) = eSheet2.Height / eTRows(ac)

                rEnemy(ac) = New Rectangle(ePosX(ac), ePosY(ac), eWidth(ac), eHeight(ac))

            ElseIf eType(ac) = 3 Then
                eDir(max) = True

                eTCols(ac) = 2
                eTRows(ac) = 1
                eWidth(ac) = eSheet3.Width / eTCols(ac)
                eHeight(ac) = eSheet3.Height / eTRows(ac)

                rEnemy(ac) = New Rectangle(ePosX(ac), ePosY(ac), eWidth(ac), eHeight(ac))

            ElseIf eType(ac) = 4 Then
                eDir(max) = True

                eTCols(ac) = 2
                eTRows(ac) = 1
                eWidth(ac) = eSheet4.Width / eTCols(ac)
                eHeight(ac) = eSheet4.Height / eTRows(ac)

                rEnemy(ac) = New Rectangle(ePosX(ac), ePosY(ac), eWidth(ac), eHeight(ac))

            End If

            ac += 1
        End If

    End Sub
    Private Sub Jump()

        'Jump ---------------------------------------------------------------------------------------------------------------------------------
        kJump = True

        If kfat = False Then
            kRow = 3
            kCol = 0
        End If

        'Fall if ------------------------------------------------------------------------------------------------------------------------------
        If kFall = True And kOn = True Then
            v1 = 15
            If v2 > 20 Then
                v2 = 20
            Else
                v2 = (v1 + (g * t))
            End If
        ElseIf kFall = True And kOn = False Then
            v1 = 15
            If v2 > 20 Then
                v2 = 20
            Else
                v2 = (v1 + (g * t))
            End If
        Else
            g = 9.8
            v1 = -25
        End If

        'Start Animation When -----------------------------------------------------------------------------------------------------------------
        If count > 0 And kfat = False And kHold = False And kSuck = False Then
            count = 0
        End If

        'Activate Jump When -------------------------------------------------------------------------------------------------------------------
        t += 0.15
        If screen = 1 Then
            If v2 > 20 Then
                v2 = 20
            Else
                v2 = (v1 + (g * t))
            End If
        ElseIf screen = 2 Then
            'Dont Move Off Screen When Falling ------------------------------------------------------------------------------------------------
            If kLand = False And kPosY < 350 Then
                v2 = 20
            Else
                v2 = 0
            End If
            If kLand = True Then
                If v2 > 20 Then
                    v2 = 20
                Else
                    v2 = (v1 + (g * t))
                End If
            End If
        End If

        kPosY += v2

    End Sub
    Private Sub AirAttack()

        'Start Animation, Create Rectangle -----------------------------------------------------------------------------------------------------
        kStart = True
        rAtk = New Rectangle(rKirby.X, rKirby.Y + rKirby.Height / 2 - kAA.Height / 2, kAA.Width, kAA.Height)
        kFirstX = rAtk.X

        'Which Way To Attack -------------------------------------------------------------------------------------------------------------------
        If kFace = True Then
            kAtkVel = 8
            kAtkDir = True
        ElseIf kFace = False Then
            kAtkVel = -8
            kAtkDir = False
        End If

    End Sub
    Private Sub FatAttack()

        'Start Animation, Create Rectangle -----------------------------------------------------------------------------------------------------
        kStart = True
        rAtk = New Rectangle(rKirby.X, rKirby.Y + rKirby.Height / 2 - kAA.Height / 2, kAA.Width, kAA.Height)
        kFirstX = rAtk.X

        'Which Way To Attack -------------------------------------------------------------------------------------------------------------------
        If kFace = True Then
            kAtkVel = 8
            kAtkDir = True
        ElseIf kFace = False Then
            kAtkVel = -8
            kAtkDir = False
        End If

    End Sub
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        score = 0

        'Non-Game Mechanic -----------------------------------------------------------------------------------------------------------------------
        wp.URL = "song.mp3"
        pfc.AddFontFile("8-BIT WONDER.ttf")

        screen = 0
        Winner = False
        rblock = New Rectangle(200, 250, 20, 20)

        'KIRBY -----------------------------------------------------------------------------------------------------------------------------------
        lives = 6

        kRow = 0
        kCol = 0

        kTCols = 4
        kTRows = 4

        kNorm = True
        kStart = False
        kHeight = kSheet.Height / kTCols
        kWidth = kSheet.Width / kTRows
        kPosY = 350

        JumpTimer.Stop()

        kRight = False
        kLeft = False
        kDown = False
        kUp = False
        kFly = False
        kfat = False
        KConsume = False
        kShoot = False
        kJump = False
        kPreFly = True

        kFall = False
        kOn = False
        kFlyAtk = False
        kMidA = False
        kSuck = False
        kRevert = False
        kHold = False
        kLand = False
        count = 0

        rAtk = New Rectangle(-1000, -1000, kAA.Width, kAA.Height)
        rKirby = New Rectangle(300, kPosY, kWidth, kHeight)

        'Rectangles ----------------------------------------------------------------------------------------------------------------------------
        b1 = New Rectangle(RecPosX, 431, 13000, 100)
        b2 = New Rectangle(RecPosX + 1300, 360, 650, 75)
        b3 = New Rectangle(RecPosX + 2530, 140, 145, 300)
        b4 = New Rectangle(RecPosX + 3545, 360, 645, 70)
        b5 = New Rectangle(RecPosX + 3620, 290, 505, 70)
        b6 = New Rectangle(RecPosX + 5280, 360, 360, 70)
        b7 = New Rectangle(RecPosX + 5425, 285, 360, 75)

        i1 = New Rectangle(RecPosX + 5675, 170, 100, 100)

        BGPosX = 0
        BGPosY = 0
        RecPosX = 0
        RecPosY = 0

        'Boss And Array ------------------------------------------------------------------------------------------------------------------------
        tLives = 3
        rTreeAtk(tc) = New Rectangle(1000, 1000, 0, 0)

        ac = 0
        tc = 0
        create = 0

    End Sub
#End Region
#Region "Refreshing Event"
    Private Sub SpriteTimer_Tick(sender As System.Object, e As System.EventArgs) Handles SpriteTimer.Tick

        'Dont Change Kirby State When... -------------------------------------------------------------------------------------------------------
        If screen = 2 Then
            If RecPosY >= -1170 Then
                kFly = False
                kfat = False
            End If
        End If

        If screen = 1 Or 2 Then
            'Kirby Non-Fly Setting -------------------------------------------------------------------------------------------------------------
            rKirby = New Rectangle(rKirby.X, kPosY, kWidth, kHeight)

            If kFly = False And kFlyAtk = True And kfat = False Then
                kFlyAtk = False
                kPreFly = True
                If kRight = False And kLeft = False Then
                    count = 0
                    kStart = False
                    kPosY += 30
                    rKirby.Y += 30
                End If
            End If

            'Start The Animation ---------------------------------------------------------------------------------------------------------------
            For ac As Integer = 0 To create - 1
                If eType(ac) >= 0 Then
                    eCol(ac) = ecount Mod eTCols(ac)
                End If
            Next

            If kStart = True And kJump = False And kfat = False Then
                kCol = count Mod kTCols
            ElseIf kStart = True And kJump = True And kfat = True Then
                kCol = count Mod kTCols
            ElseIf kStart = True And kFly = True And kfat = False Then
                kCol = count Mod kTCols
            ElseIf kStart = True And kfat = True Then
                kCol = count Mod kTCols
            End If

            count += 1
            ecount += 1

            'Stop or Loop The Animation --------------------------------------------------------------------------------------------------------------
            If count >= 4 And kJump = False And kFly = False And kfat = False Then
                count = 0
            ElseIf kFly = True And count > 4 And kFlyAtk = False And kfat = False Then
                count = 3
            ElseIf kfat = True And count > 3 And kHold = True Then
                count = 2
            ElseIf kfat = True And count > 6 And kHold = False And kSuck = False And KConsume = False Then
                count = 0
            End If

            'Flying Animation ------------------------------------------------------------------------------------------------------------------------
            If kFlyAtk = True And count > 7 Then
                count = 0
                kFly = False

                kTCols = 4
                kTRows = 4

                kHeight = kSheet.Height / kTCols
                kWidth = kSheet.Width / kTRows
                rKirby = New Rectangle(rKirby.X, kPosY + 30, kWidth, kHeight)

                kNorm = True
            End If

            'Kirby Fat Animation ---------------------------------------------------------------------------------------------------------------------
            If kfat = True And kSuck = True Then
                kCol = 1
            ElseIf kfat = True And count > 3 And kHold = True Then
                count += 1
                count = 2
                kCol = 2
            End If

            'When State is Chosen then... ------------------------------------------------------------------------------------------------------
            If kfat = True And kShoot = True Then
                kStart = True
            End If

            If kfat = True And KConsume = True Then
                kStart = True
            End If

            If kCol >= 5 And kfat = True Then
                kRevert = True
            End If

            'Revert Back To Normal State -------------------------------------------------------------------------------------------------------
            If kfat = True And kRevert = True Then
                kCol = 0

                If kRight = False And kLeft = False Then
                    kRow = 0
                ElseIf kRight = True Then
                    kRow = 1
                    kStart = True
                ElseIf kLeft = True Then
                    kRow = 2
                    kStart = True
                End If

                kStart = False
                kTCols = 4
                kTRows = 4
                kHeight = kSheet.Height / kTCols
                kWidth = kSheet.Width / kTRows
                kPosY += 30
                rKirby = New Rectangle(rKirby.X, kPosY, kWidth, kHeight)

                kFly = False
                kfat = False
                kSuck = False
                kHold = False
                KConsume = False

                kNorm = True
                kfat = False
                kRevert = False
            End If
        End If

        Me.Refresh()

    End Sub
    Private Sub Form1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint

        'Paint Screen 0 ------------------------------------------------------------------------------------------------------------------------
        If screen = 0 Then
            e.Graphics.DrawImage(title, 0, 0, 687, 662)
        End If

        'Paint Screen 1 ------------------------------------------------------------------------------------------------------------------------
        If screen = 1 Then

            'BG --------------------------------------------------------------------------------------------------------------------------------
            If BGPosX <= 0 And BGPosX >= -700 Then
                e.Graphics.DrawImage(BG1, BGPosX, 0, BG1.Width, BG1.Height)
            End If
            If BGPosX <= 0 And BGPosX >= -1400 Then
                e.Graphics.DrawImage(BG2, BGPosX + 700, 0, BG2.Width, BG2.Height)
            End If
            If BGPosX <= -700 And BGPosX >= -2100 Then
                e.Graphics.DrawImage(BG3, BGPosX + 1400, 0, BG3.Width, BG3.Height)
            End If
            If BGPosX <= -1400 And BGPosX >= -2800 Then
                e.Graphics.DrawImage(BG4, BGPosX + 2100, 0, BG4.Width, BG4.Height)
            End If
            If BGPosX <= -2100 And BGPosX >= -3500 Then
                e.Graphics.DrawImage(BG5, BGPosX + 2800, 0, BG5.Width, BG5.Height)
            End If
            If BGPosX <= -2800 And BGPosX >= -4200 Then
                e.Graphics.DrawImage(BG6, BGPosX + 3500, 0, BG6.Width, BG6.Height)
            End If
            If BGPosX <= -3500 And BGPosX >= -4900 Then
                e.Graphics.DrawImage(BG7, BGPosX + 4200, 0, BG7.Width, BG7.Height)
            End If
            If BGPosX <= -4200 And BGPosX >= -5600 Then
                e.Graphics.DrawImage(BG8, BGPosX + 4900, 0, BG8.Width, BG8.Height)
            End If
            If BGPosX <= -4900 And BGPosX >= -6300 Then
                e.Graphics.DrawImage(BG9, BGPosX + 5600, 0, BG9.Width, BG9.Height)
            End If

            'STAGE RECTANGLES ------------------------------------------------------------------------------------------------------------------
            'e.Graphics.DrawRectangle(Pens.Red, rKirby)
            'e.Graphics.DrawRectangle(Pens.Red, rDetect)

            'e.Graphics.DrawRectangle(Pens.Red, b1)
            'e.Graphics.DrawRectangle(Pens.Red, b2)
            'e.Graphics.DrawRectangle(Pens.Red, b3)
            'e.Graphics.DrawRectangle(Pens.Red, b4)
            'e.Graphics.DrawRectangle(Pens.Red, b5)
            'e.Graphics.DrawRectangle(Pens.Red, b6)
            'e.Graphics.DrawRectangle(Pens.Red, b7)

            'e.Graphics.DrawRectangle(Pens.Blue, r1)
            'e.Graphics.DrawRectangle(Pens.Blue, r2)
            'e.Graphics.DrawRectangle(Pens.Blue, r3)
            'e.Graphics.DrawRectangle(Pens.Blue, r4)
            'e.Graphics.DrawRectangle(Pens.Blue, r5)
            'e.Graphics.DrawRectangle(Pens.Blue, r6)
            'e.Graphics.DrawRectangle(Pens.Blue, r7)
            'e.Graphics.DrawRectangle(Pens.Blue, r8)

            'e.Graphics.DrawRectangle(Pens.Red, i1)

            'ENEMY -----------------------------------------------------------------------------------------------------------------------------
            For ac As Integer = 0 To create - 1
                If eType(ac) = 1 And eDir(ac) = True Then
                    e.Graphics.DrawImage(eSheet1, rEnemy(ac), New RectangleF(eCol(ac) * eWidth(ac), eRow(ac) * eHeight(ac), eWidth(ac), eHeight(ac)), GraphicsUnit.Pixel)
                ElseIf eType(ac) = 2 And eDir(ac) = True Then
                    e.Graphics.DrawImage(eSheet2, rEnemy(ac), New RectangleF(eCol(ac) * eWidth(ac), eRow(ac) * eHeight(ac), eWidth(ac), eHeight(ac)), GraphicsUnit.Pixel)
                ElseIf eType(ac) = 3 And eDir(ac) = True Then
                    e.Graphics.DrawImage(eSheet3, rEnemy(ac), New RectangleF(eCol(ac) * eWidth(ac), eRow(ac) * eHeight(ac), eWidth(ac), eHeight(ac)), GraphicsUnit.Pixel)
                ElseIf eType(ac) = 4 And eDir(ac) = True Then
                    e.Graphics.DrawImage(eSheet4, rEnemy(ac), New RectangleF(eCol(ac) * eWidth(ac), eRow(ac) * eHeight(ac), eWidth(ac), eHeight(ac)), GraphicsUnit.Pixel)
                End If

                If eType(ac) = 1 And eDir(ac) = False Then
                    e.Graphics.DrawImage(eSheet1b, rEnemy(ac), New RectangleF(eCol(ac) * eWidth(ac), eRow(ac) * eHeight(ac), eWidth(ac), eHeight(ac)), GraphicsUnit.Pixel)
                ElseIf eType(ac) = 2 And eDir(ac) = False Then
                    e.Graphics.DrawImage(eSheet2b, rEnemy(ac), New RectangleF(eCol(ac) * eWidth(ac), eRow(ac) * eHeight(ac), eWidth(ac), eHeight(ac)), GraphicsUnit.Pixel)
                ElseIf eType(ac) = 3 And eDir(ac) = False Then
                    e.Graphics.DrawImage(eSheet3b, rEnemy(ac), New RectangleF(eCol(ac) * eWidth(ac), eRow(ac) * eHeight(ac), eWidth(ac), eHeight(ac)), GraphicsUnit.Pixel)
                ElseIf eType(ac) = 4 And eDir(ac) = False Then
                    e.Graphics.DrawImage(eSheet4b, rEnemy(ac), New RectangleF(eCol(ac) * eWidth(ac), eRow(ac) * eHeight(ac), eWidth(ac), eHeight(ac)), GraphicsUnit.Pixel)
                End If

                ' e.Graphics.DrawRectangle(Pens.Black, rEnemy(ac))
            Next
        End If

        'Paint Screen 2 ------------------------------------------------------------------------------------------------------------------------
        If screen = 2 Then

            'BACKGROUND IMAGE ------------------------------------------------------------------------------------------------------------------
            e.Graphics.DrawImage(BG10, 0, BGPosY, BG10.Width, BG10.Height)
            e.Graphics.DrawImage(BG11, 0, BGPosY + 700, BG11.Width, BG11.Height)

            'STAGE RECTANGLES ------------------------------------------------------------------------------------------------------------------
            'e.Graphics.DrawRectangle(Pens.Red, rKirby)
            'e.Graphics.DrawRectangle(Pens.Red, rDetect)

            'e.Graphics.DrawRectangle(Pens.Red, b8)
            'e.Graphics.DrawRectangle(Pens.Red, b9)
            'e.Graphics.DrawRectangle(Pens.Red, b10)
            'e.Graphics.DrawRectangle(Pens.Red, b11)
            'e.Graphics.DrawRectangle(Pens.Red, b12)
            'e.Graphics.DrawRectangle(Pens.Red, b13)

            'ATTACK RECTANGLES -----------------------------------------------------------------------------------------------------------------
            If RecPosY <= -1170 Then
                For tc As Integer = 0 To tCreate - 1
                    e.Graphics.DrawImage(tAtk, rTreeAtk(tc))
                    '    e.Graphics.DrawRectangle(Pens.Green, rTreeAtk(tc))
                Next
            End If

            'TREE IMAGE ------------------------------------------------------------------------------------------------------------------------
            If tFace = 1 Then
                e.Graphics.DrawImage(treeFace1, rTFace)
            ElseIf tFace = 2 Then
                e.Graphics.DrawImage(treeFace2, rTFace)
            End If

            'APPLE IMAGE -----------------------------------------------------------------------------------------------------------------------
            If AppleSpawn = True And RecPosY >= -1770 Then
                e.Graphics.DrawImage(apple, rApple)
            End If
        End If

        'Universal Game Images -----------------------------------------------------------------------------------------------------------------
        If screen = 1 Or screen = 2 Then

            'ATTACK ----------------------------------------------------------------------------------------------------------------------------
            '  e.Graphics.DrawRectangle(Pens.Red, rAtk)

            If kSuck = True And kfat = True And kCol = 1 And kFace = True Then
                rSuck = New Rectangle(rKirby.X + kWidth, rKirby.Y, 100, kWidth)
            ElseIf kSuck = True And kfat = True And kCol = 1 And kFace = False Then
                rSuck = New Rectangle(rKirby.X - 100, rKirby.Y, 100, kWidth)
            End If

            If kAirAtk = True And kAtkDir = True Then
                e.Graphics.DrawImage(kAA, rAtk)
            ElseIf kAirAtk = True And kAtkDir = False Then
                e.Graphics.DrawImage(kAA2, rAtk)
            ElseIf kShoot = True Then
                e.Graphics.DrawImage(kFA, rAtk)
            ElseIf kSuck = True And kCol = 1 And kfat = True Then
                'e.Graphics.DrawRectangle(Pens.Red, rSuck)
            End If

            'KIRBY -----------------------------------------------------------------------------------------------------------------------------
            If kNorm = True And kFly = False And kfat = False Then
                e.Graphics.DrawImage(kSheet, rKirby, New RectangleF(kCol * kWidth, kRow * kHeight, kWidth, kHeight), GraphicsUnit.Pixel)
            ElseIf kFly = True And kFace = True And kfat = False Then
                e.Graphics.DrawImage(kFloat, rKirby, New RectangleF(kCol * kWidth, kRow * kHeight, kWidth, kHeight), GraphicsUnit.Pixel)
            ElseIf kFly = True And kFace = False And kfat = False Then
                e.Graphics.DrawImage(kFloat2, rKirby, New RectangleF(kCol * kWidth, kRow * kHeight, kWidth, kHeight), GraphicsUnit.Pixel)
            ElseIf kfat = True And kShoot = False And KConsume = False And kFace = True Then
                e.Graphics.DrawImage(kBig, rKirby, New RectangleF(kCol * kWidth, kRow * kHeight, kWidth, kHeight), GraphicsUnit.Pixel)
            ElseIf kShoot = True And kFace = True Then
                e.Graphics.DrawImage(kBig1, rKirby, New RectangleF(kCol * kWidth, kRow * kHeight, kWidth, kHeight), GraphicsUnit.Pixel)
            ElseIf KConsume = True And kFace = True Then
                e.Graphics.DrawImage(kBig2, rKirby, New RectangleF(kCol * kWidth, kRow * kHeight, kWidth, kHeight), GraphicsUnit.Pixel)
            ElseIf kfat = True And kShoot = False And KConsume = False And kFace = False Then
                e.Graphics.DrawImage(kBig3, rKirby, New RectangleF(kCol * kWidth, kRow * kHeight, kWidth, kHeight), GraphicsUnit.Pixel)
            ElseIf kShoot = True And kFace = False Then
                e.Graphics.DrawImage(kBig4, rKirby, New RectangleF(kCol * kWidth, kRow * kHeight, kWidth, kHeight), GraphicsUnit.Pixel)
            ElseIf KConsume = True And kFace = False Then
                e.Graphics.DrawImage(kBig5, rKirby, New RectangleF(kCol * kWidth, kRow * kHeight, kWidth, kHeight), GraphicsUnit.Pixel)
            End If

            'GAME ------------------------------------------------------------------------------------------------------------------------------

            e.Graphics.FillRectangle(Brushes.WhiteSmoke, 0, 520, 700, 200)
            e.Graphics.DrawRectangle(Pens.Black, 20, 540, 640, 100)

            e.Graphics.DrawImage(LiveImg, 20, 590, LiveImg.Width, LiveImg.Height)
            e.Graphics.DrawImage(ScoreImg, 30, 545, ScoreImg.Width, ScoreImg.Height)
            e.Graphics.DrawString(score, New System.Drawing.Font(pfc.Families(0), 25, FontStyle.Regular), Brushes.Black, 200, 548)

            e.Graphics.DrawRectangle(Pens.Black, 390, 597, 30, 30)
            e.Graphics.DrawRectangle(Pens.Black, 350, 597, 30, 30)
            e.Graphics.DrawRectangle(Pens.Black, 310, 597, 30, 30)
            e.Graphics.DrawRectangle(Pens.Black, 270, 597, 30, 30)
            e.Graphics.DrawRectangle(Pens.Black, 230, 597, 30, 30)
            e.Graphics.DrawRectangle(Pens.Black, 190, 597, 30, 30)

            If lives = 6 Then
                e.Graphics.FillRectangle(Brushes.Black, 393, 600, 25, 25)
                e.Graphics.FillRectangle(Brushes.Black, 353, 600, 25, 25)
                e.Graphics.FillRectangle(Brushes.Black, 313, 600, 25, 25)
                e.Graphics.FillRectangle(Brushes.Black, 273, 600, 25, 25)
                e.Graphics.FillRectangle(Brushes.Black, 233, 600, 25, 25)
                e.Graphics.FillRectangle(Brushes.Black, 193, 600, 25, 25)
            ElseIf lives = 5 Then
                e.Graphics.FillRectangle(Brushes.Black, 353, 600, 25, 25)
                e.Graphics.FillRectangle(Brushes.Black, 313, 600, 25, 25)
                e.Graphics.FillRectangle(Brushes.Black, 273, 600, 25, 25)
                e.Graphics.FillRectangle(Brushes.Black, 233, 600, 25, 25)
                e.Graphics.FillRectangle(Brushes.Black, 193, 600, 25, 25)
            ElseIf lives = 4 Then
                e.Graphics.FillRectangle(Brushes.Black, 313, 600, 25, 25)
                e.Graphics.FillRectangle(Brushes.Black, 273, 600, 25, 25)
                e.Graphics.FillRectangle(Brushes.Black, 233, 600, 25, 25)
                e.Graphics.FillRectangle(Brushes.Black, 193, 600, 25, 25)
            ElseIf lives = 3 Then
                e.Graphics.FillRectangle(Brushes.Black, 273, 600, 25, 25)
                e.Graphics.FillRectangle(Brushes.Black, 233, 600, 25, 25)
                e.Graphics.FillRectangle(Brushes.Black, 193, 600, 25, 25)
            ElseIf lives = 2 Then
                e.Graphics.FillRectangle(Brushes.Black, 233, 600, 25, 25)
                e.Graphics.FillRectangle(Brushes.Black, 193, 600, 25, 25)
            ElseIf lives = 1 Then
                e.Graphics.FillRectangle(Brushes.Black, 193, 600, 25, 25)
            End If
        End If

        'Paint Screen 3 ------------------------------------------------------------------------------------------------------------------------
        If screen = 3 Then
            If lives <= 0 Then
                e.Graphics.DrawImage(_end, 0, 0, 687, 662)
                e.Graphics.FillRectangle(Brushes.Black, rblock)
            ElseIf lives > 0 Then
                e.Graphics.DrawImage(win, 0, 0, 687, 662)
                e.Graphics.FillRectangle(Brushes.Black, rblock)
                e.Graphics.DrawString(score, New System.Drawing.Font(pfc.Families(0), 25, FontStyle.Regular), Brushes.Black, 330, 110)
            End If
        End If

    End Sub
    Private Sub Enemy_Tick(sender As System.Object, e As System.EventArgs) Handles Enemy.Tick

        'Restart Boss Attack Arrays ------------------------------------------------------------------------------------------------------------
        If tBurst = True Then
            tBurst = False
            tc = 0
            tCreate = 0
            tAtkReload = True
        End If

        'Screen 1 Enemies ----------------------------------------------------------------------------------------------------------------------
        If screen = 1 Then

            r1 = New Rectangle(RecPosX + 1300, 0, 75, 400)
            r2 = New Rectangle(RecPosX + 1940, 0, 75, 400)
            r3 = New Rectangle(RecPosX + 2675, 0, 75, 500)
            r4 = New Rectangle(RecPosX + 3545, 0, 75, 500)
            r5 = New Rectangle(RecPosX + 3620, 0, 75, 500)
            r6 = New Rectangle(RecPosX + 4100, 0, 75, 500)
            r7 = New Rectangle(RecPosX + 4200, 0, 75, 500)
            r8 = New Rectangle(RecPosX + 5250, 0, 75, 500)

            'Spawn Enemy When... ---------------------------------------------------------------------------------------------------------------
            If RecPosX <= -500 And ac = 0 Then
                eType(ac) = 1
                ePosY(ac) = 360 - 80
                ePosX(ac) = rnd.Next(r1.X + 60, r2.X - 60)
                SpawnEnemy()
            ElseIf RecPosX <= -500 And ac = 1 Then
                eType(ac) = 2
                ePosY(ac) = 50
                ePosX(ac) = rnd.Next(r1.X + 60, r2.X - 60)
                SpawnEnemy()
            ElseIf RecPosX <= -1300 And ac = 2 Then
                eType(ac) = 2
                ePosY(ac) = 50
                ePosX(ac) = rnd.Next(r3.X + 60, r4.X - 60)
                SpawnEnemy()
            ElseIf RecPosX <= -1300 And ac = 3 Then
                eType(ac) = 1
                ePosY(ac) = 350
                ePosX(ac) = rnd.Next(r3.X + 60, r4.X - 60)
                SpawnEnemy()
            ElseIf RecPosX <= -1300 And ac = 4 Then
                eType(ac) = 3
                ePosY(ac) = 350
                ePosX(ac) = rnd.Next(r3.X + 60, r4.X - 60)
                SpawnEnemy()
            ElseIf RecPosX <= -2000 And ac = 5 Then
                eType(ac) = 3
                ePosY(ac) = 210
                ePosX(ac) = rnd.Next(r5.X + 60, r6.X - 60)
                SpawnEnemy()
            ElseIf RecPosX <= -3500 And ac = 6 Then
                eType(ac) = 3
                ePosY(ac) = 350
                ePosX(ac) = rnd.Next(r7.X + 60, r8.X - 60)
                SpawnEnemy()
            ElseIf RecPosX <= -3500 And ac = 7 Then
                eType(ac) = 2
                ePosY(ac) = 50
                ePosX(ac) = rnd.Next(r7.X + 60, r8.X - 60)
                SpawnEnemy()
            ElseIf RecPosX <= -3500 And ac = 8 Then
                eType(ac) = 3
                ePosY(ac) = 350
                ePosX(ac) = rnd.Next(r7.X + 60, r8.X - 60)
                SpawnEnemy()
            End If

            'ENEMY INTERSECTION ----------------------------------------------------------------------------------------------------------------
            For ac As Integer = 0 To create - 1

                If rKirby.IntersectsWith(rEnemy(ac)) And kSuck = False Then
                    lives -= 1
                    rEnemy(ac).Y += 1000
                End If
                If rKirby.IntersectsWith(rEnemy(ac)) And kSuck = True And kFace = True And rEnemy(ac).X < rKirby.X Then
                    lives -= 1
                    rEnemy(ac).Y += 1000
                End If
                If rKirby.IntersectsWith(rEnemy(ac)) And kSuck = True And kFace = False And rEnemy(ac).X > rKirby.X Then
                    lives -= 1
                    rEnemy(ac).Y += 1000
                End If

                If rAtk.IntersectsWith(rEnemy(ac)) Then
                    score += 500
                    rEnemy(ac).Y += 1000
                    rAtk.Y += 2000
                End If

                If rDetect.IntersectsWith(rEnemy(ac)) And kJump = False And kSuck = True And kFace = True And rEnemy(ac).X > rKirby.X And kCol = 1 Or rDetect.IntersectsWith(rEnemy(ac)) And kJump = False And kSuck = True And kFace = False And rEnemy(ac).X < rKirby.X And kCol = 1 Then
                    score += 300
                    kCol = 2
                    count = 2
                    kHold = True
                    kStart = True
                    kSuck = False
                    rEnemy(ac).Y += 1000
                End If

                If rKirby.IntersectsWith(rEnemy(ac)) And kJump = True And kSuck = True And kFace = True And rEnemy(ac).X > rKirby.X And kCol = 1 Or rKirby.IntersectsWith(rEnemy(ac)) And kJump = True And kSuck = True And kFace = False And rEnemy(ac).X < rKirby.X And kCol = 1 Then
                    score += 300
                    kCol = 2
                    count = 2
                    kHold = True
                    kStart = True
                    kSuck = False
                    rEnemy(ac).Y += 1000
                End If
            Next

            'Change direction When... ----------------------------------------------------------------------------------------------------------
            For ac As Integer = 0 To create - 1

                If rEnemy(ac).IntersectsWith(r1) Or rEnemy(ac).IntersectsWith(r3) Or rEnemy(ac).IntersectsWith(r5) Or rEnemy(ac).IntersectsWith(r7) Then
                    eDir(ac) = True
                End If
                If rEnemy(ac).IntersectsWith(r2) Or rEnemy(ac).IntersectsWith(r4) Or rEnemy(ac).IntersectsWith(r6) Or rEnemy(ac).IntersectsWith(r8) Then
                    eDir(ac) = False
                End If

                If kRight = True And eDir(ac) = False And rKirby.X >= 400 And Not rSuck.IntersectsWith(rEnemy(ac)) Then
                    eVelX(ac) = 8
                ElseIf kRight = True And eDir(ac) = False And rKirby.X <= 400 And Not rSuck.IntersectsWith(rEnemy(ac)) Then
                    eVelX(ac) = 4
                End If

                If kRight = False And eDir(ac) = False And Not rSuck.IntersectsWith(rEnemy(ac)) Then
                    eVelX(ac) = 4
                End If

                If kRight = True And eDir(ac) = True And rKirby.X >= 400 And Not rSuck.IntersectsWith(rEnemy(ac)) Then
                    eVelX(ac) = 0
                ElseIf kRight = True And eDir(ac) = True And rKirby.X <= 400 And Not rSuck.IntersectsWith(rEnemy(ac)) Then
                    eVelX(ac) = -4
                End If

                If kRight = False And eDir(ac) = True And Not rSuck.IntersectsWith(rEnemy(ac)) Then
                    eVelX(ac) = -4
                End If

                If rSuck.IntersectsWith(rEnemy(ac)) And kSuck = True And kFace = True And eDir(ac) = False Then
                    eVelX(ac) += 1
                ElseIf rSuck.IntersectsWith(rEnemy(ac)) And kSuck = True And kFace = True And eDir(ac) = True Then
                    eVelX(ac) += 1
                ElseIf rSuck.IntersectsWith(rEnemy(ac)) And kSuck = True And kFace = False And eDir(ac) = False Then
                    eVelX(ac) -= 1
                ElseIf rSuck.IntersectsWith(rEnemy(ac)) And kSuck = True And kFace = False And eDir(ac) = True Then
                    eVelX(ac) -= 1
                End If
            Next

            'ENEMY MVMNT -----------------------------------------------------------------------------------------------------------------------
            For ac As Integer = 0 To create - 1

                If eType(ac) = 1 Then
                    rEnemy(ac).X -= eVelX(ac)
                ElseIf eType(ac) = 2 Then
                    rEnemy(ac).X -= eVelX(ac)
                ElseIf eType(ac) = 3 Then
                    rEnemy(ac).X -= eVelX(ac)
                ElseIf eType(ac) = 4 Then
                    rEnemy(ac).X -= eVelX(ac)
                End If
            Next
        End If

        'Screen 2 Enemies and Entities ---------------------------------------------------------------------------------------------------------
        If screen = 2 Then

            'Apple -----------------------------------------------------------------------------------------------------------------------------
            If rSuck.IntersectsWith(rApple) And kSuck = True And kFace = True Then
                aVelx += 1
            ElseIf rSuck.IntersectsWith(rApple) And kSuck = True And kFace = False Then
                aVelx -= 1
            End If

            If rKirby.IntersectsWith(rApple) And kSuck = True And kfat = True And rSuck.IntersectsWith(rApple) Then
                score += 300
                kCol = 2
                count = 2
                kHold = True
                kStart = True
                kSuck = False
                rApple.Y += 1000
            End If
            rApple.X -= aVelx

            'If Tree Arrays and Tree Interactions ----------------------------------------------------------------------------------------------
            For tc As Integer = 0 To tCreate - 1
                If rKirby.IntersectsWith(rTreeAtk(tc)) Then
                    lives -= 2
                    rTreeAtk(tc).Y += 1000
                End If
            Next

            If tLives <= 0 And lives > 1 And screen = 2 Then
                rblock = New Rectangle(48, 165, 20, 20)
                Winner = True
                screen = 3
            End If

            If b12.IntersectsWith(rAtk) Then
                rAtk.Y += 1000
                tLives -= 1
            End If
        End If

    End Sub
    Private Sub Boss_Tick(sender As System.Object, e As System.EventArgs) Handles Boss.Tick

        'Boss Timer -----------------------------------------------------------------------------------------------------------------------------
        If screen = 2 And RecPosY <= -1170 Then
            BossAttack()

            'Start Reload Timer -----------------------------------------------------------------------------------------------------------------
            If tAtkTime > 0 And tAtkTick = True Then
                tAtkTime -= 1

                'When Reload Timer is Done, Attack ----------------------------------------------------------------------------------------------
            ElseIf tAtkTime <= 0 Then
                If Not kSuck = True And Not rSuck.IntersectsWith(rApple) Then
                    AppleSpawn = False
                End If
                tBurst = True
                tAtkTick = False
                tAtkTime = 5
            End If
        End If

    End Sub
    Private Sub Intersect_Tick(sender As System.Object, e As System.EventArgs) Handles Intersect.Tick

        'Label1.Text = kCol
        'Label2.Text = kRevert

        'If Lives... ---------------------------------------------------------------------------------------------------------------------------
        If lives <= 0 And screen = 2 Or lives <= 0 And screen = 1 Then
            rblock = New Rectangle(200, 250, 20, 20)
            screen = 3
        End If

        If screen = 1 Then

            'ENVIROMENT-------------------------------------------------------------------------------------------------------------------------
            'If Kirby is on a Platform ---------------------------------------------------------------------------------------------------------
            If kOn = True And kFly = False And kfat = False And kRevert = False Then
                If kRight = False And kLeft = False And kfat = False Then
                    kRow = 0
                    kCol = 0
                ElseIf kRight = True And kfat = False Then
                    kRow = 1
                    kStart = True
                ElseIf kLeft = True And kfat = False Then
                    kRow = 2
                    kStart = True
                End If
            End If

            'If Kirby runs into the platform (Walls)... ----------------------------------------------------------------------------------------
            If rKirby.IntersectsWith(b2) And rDetect.Y >= b2.Y And kRight = True And rDetect.X + rDetect.Width <= b2.X + 50 Then
                kVelX = 0
                kRight = False
            ElseIf rKirby.IntersectsWith(b2) And rDetect.Y >= b2.Y And kLeft = True And rDetect.X >= b2.X + b2.Width - 50 Then
                kVelX = 0
                kLeft = False
            ElseIf rKirby.IntersectsWith(b3) And rDetect.Y >= b3.Y And kRight = True And rDetect.X + rDetect.Width <= b3.X + 50 Then
                kVelX = 0
                kRight = False
            ElseIf rKirby.IntersectsWith(b3) And rDetect.Y >= b3.Y And kLeft = True And rDetect.X >= b3.X + b3.Width - 50 Then
                kVelX = 0
                kLeft = False
            ElseIf rKirby.IntersectsWith(b4) And rDetect.Y >= b4.Y And kRight = True And rDetect.X + rDetect.Width <= b4.X + 50 Then
                kVelX = 0
                kRight = False
                kOn = False
            ElseIf rKirby.IntersectsWith(b4) And rDetect.Y >= b4.Y And kLeft = True And rDetect.X >= b4.X + b4.Width - 50 Then
                kVelX = 0
                kLeft = False
                kOn = False
            ElseIf rKirby.IntersectsWith(b5) And rDetect.Y >= b5.Y And kRight = True And rDetect.X + rDetect.Width <= b5.X + 50 Then
                kVelX = 0
                kRight = False
                kOn = False
            ElseIf rKirby.IntersectsWith(b5) And rDetect.Y >= b5.Y And kLeft = True And rDetect.X >= b5.X + b5.Width - 50 Then
                kVelX = 0
                kLeft = False
                kOn = False
            ElseIf rKirby.IntersectsWith(b6) And rDetect.Y >= b6.Y And kRight = True And rDetect.X + rDetect.Width <= b6.X + 50 Then
                kVelX = 0
                kRight = False
                kOn = False
            ElseIf rKirby.IntersectsWith(b7) And rDetect.Y >= b7.Y And kRight = True And rDetect.X + rDetect.Width <= b7.X + 50 Then
                kVelX = 0
                kRight = False
                kOn = False
            ElseIf kRight = True And rKirby.X + kWidth <= b7.X + b7.Width Then
                kVelX = 4
                rKirby.X += kVelX
                kStart = True
            ElseIf kLeft = True Then
                kVelX = 4
                rKirby.X -= kVelX
                kStart = True
            End If

            If rKirby.IntersectsWith(b2) And rDetect.Y - 30 >= b2.Y And rDetect.X + rDetect.Width <= b2.X + 50 Then
                rKirby.X = b2.X - rKirby.Width + 1
            ElseIf rKirby.IntersectsWith(b2) And rDetect.Y - 30 >= b2.Y And rDetect.X >= b2.X + b2.Width - 50 Then
                rKirby.X = b2.X + b2.Width - 1
            ElseIf rKirby.IntersectsWith(b3) And rDetect.Y - 30 >= b3.Y And rDetect.X + rDetect.Width <= b3.X + 50 Then
                rKirby.X = b3.X - rKirby.Width + 1
            ElseIf rKirby.IntersectsWith(b3) And rDetect.Y - 30 >= b3.Y And rDetect.X >= b3.X + b3.Width - 50 Then
                rKirby.X = b3.X + b3.Width - 1
            ElseIf rKirby.IntersectsWith(b4) And rDetect.Y - 30 >= b4.Y And rDetect.X + rDetect.Width <= b4.X + 50 Then
                rKirby.X = b4.X - rKirby.Width + 1
            ElseIf rKirby.IntersectsWith(b4) And rDetect.Y - 30 >= b4.Y And rDetect.X >= b4.X + b4.Width - 50 Then
                rKirby.X = b4.X + b4.Width - 1
            ElseIf rKirby.IntersectsWith(b5) And rDetect.Y - 30 >= b5.Y And rDetect.X + rDetect.Width <= b5.X + 50 Then
                rKirby.X = b5.X - rKirby.Width + 1
            ElseIf rKirby.IntersectsWith(b5) And rDetect.Y - 30 >= b5.Y And rDetect.X >= b5.X + b5.Width - 50 Then
                rKirby.X = b5.X + b5.Width - 1
            ElseIf rKirby.IntersectsWith(b6) And rDetect.Y - 30 >= b6.Y And rDetect.X + rDetect.Width <= b6.X + 50 Then
                rKirby.X = b6.X - rKirby.Width + 1
            ElseIf rKirby.IntersectsWith(b6) And rDetect.Y - 30 >= b6.Y And rDetect.X >= b6.X + b6.Width - 50 Then
                rKirby.X = b6.X + b6.Width - 1
            ElseIf rKirby.IntersectsWith(b7) And rDetect.Y - 30 >= b7.Y And rDetect.X + rDetect.Width <= b7.X + 50 Then
                rKirby.X = b7.X - rKirby.Width + 1
            ElseIf rKirby.IntersectsWith(b7) And rDetect.Y - 30 >= b7.Y And rDetect.X >= b7.X + b7.Width - 50 Then
                rKirby.X = b7.X + b7.Width - 1
            End If

            'If Kirby is on the platform (Not Flying)... ---------------------------------------------------------------------------------------
            If rDetect.IntersectsWith(b2) And rDetect.Y <= b2.Y + 50 And kFly = False And kHold = False Then
                kJump = False
                JumpTimer.Stop()
                rKirby.Y = b2.Y - kHeight + 10
                kPosY = b2.Y - kHeight + 10
                t = 0
                kFall = False
                kOn = True
            ElseIf rDetect.IntersectsWith(b3) And rDetect.Y <= b3.Y + 50 And kFly = False And kHold = False Then
                kJump = False
                JumpTimer.Stop()
                rKirby.Y = b3.Y - kHeight + 10
                kPosY = b3.Y - kHeight + 10
                t = 0
                kFall = False
                kOn = True
            ElseIf rDetect.IntersectsWith(b4) And rDetect.Y <= b4.Y + 50 And kFly = False And kHold = False Then
                kJump = False
                JumpTimer.Stop()
                rKirby.Y = b4.Y - kHeight + 10
                kPosY = b4.Y - kHeight + 10
                t = 0
                kFall = False
                kOn = True
            ElseIf rDetect.IntersectsWith(b5) And rDetect.Y <= b5.Y + 50 And kFly = False And kHold = False Then
                kJump = False
                JumpTimer.Stop()
                rKirby.Y = b5.Y - kHeight + 10
                kPosY = b5.Y - kHeight + 10
                t = 0
                kFall = False
                kOn = True
            ElseIf rDetect.IntersectsWith(b6) And rDetect.Y <= b6.Y + 50 And kFly = False And kHold = False Then
                kJump = False
                JumpTimer.Stop()
                rKirby.Y = b6.Y - kHeight + 10
                kPosY = b6.Y - kHeight + 10
                t = 0
                kFall = False
                kOn = True
            ElseIf rDetect.IntersectsWith(b7) And rDetect.Y <= b7.Y + 50 And kFly = False And kHold = False Then
                kJump = False
                JumpTimer.Stop()
                rKirby.Y = b7.Y - kHeight + 10
                kPosY = b7.Y - kHeight + 10
                t = 0
                kFall = False
                kOn = True
            End If

            'If Kirby is on the platform (Flying)... -------------------------------------------------------------------------------------------
            If rDetect.IntersectsWith(b1) And rDetect.Y < b1.Y And kFly = True And kHold = False Then
                kPosY = rKirby.Y
                kVelY = 0
                kMidA = False
                JumpTimer.Stop()
            ElseIf rDetect.IntersectsWith(b2) And rDetect.Y < b2.Y And kFly = True And kHold = False Then
                kPosY = rKirby.Y
                kVelY = 0
                kMidA = False
                JumpTimer.Stop()
            ElseIf rDetect.IntersectsWith(b3) And rDetect.Y < b3.Y And kFly = True And kHold = False Then
                kPosY = rKirby.Y
                kVelY = 0
                kMidA = False
                JumpTimer.Stop()
            ElseIf rDetect.IntersectsWith(b4) And rDetect.Y < b4.Y And kFly = True And kHold = False Then
                kPosY = rKirby.Y
                kVelY = 0
                kMidA = False
                JumpTimer.Stop()
            ElseIf rDetect.IntersectsWith(b5) And rDetect.Y < b5.Y And kFly = True And kHold = False Then
                kPosY = rKirby.Y
                kVelY = 0
                kMidA = False
                JumpTimer.Stop()
            ElseIf rDetect.IntersectsWith(b6) And rDetect.Y < b6.Y And kFly = True And kHold = False Then
                kPosY = rKirby.Y
                kVelY = 0
                kMidA = False
                JumpTimer.Stop()
            ElseIf rDetect.IntersectsWith(b7) And rDetect.Y < b7.Y And kFly = True And kHold = False Then
                kPosY = rKirby.Y
                kVelY = 0
                kMidA = False
                JumpTimer.Stop()
            Else
                JumpTimer.Start()
            End If

            'If Kirby is on the platform (Fat)... ----------------------------------------------------------------------------------------------
            If rDetect.IntersectsWith(b2) And rDetect.Y <= b2.Y + 50 And kFly = False And kfat = True And kHold = True Then
                t = 0
                JumpTimer.Stop()
                kFall = False
                kOn = True
                kJump = False
                rKirby.Y = b2.Y - kHeight + 8
                kPosY = b2.Y - kHeight + 8
            ElseIf rDetect.IntersectsWith(b3) And rDetect.Y <= b3.Y + 50 And kFly = False And kfat = True And kHold = True Then
                t = 0
                JumpTimer.Stop()
                kFall = False
                kOn = True
                kJump = False
                rKirby.Y = b3.Y - kHeight + 8
                kPosY = b3.Y - kHeight + 8
            ElseIf rDetect.IntersectsWith(b4) And rDetect.Y <= b4.Y + 50 And kFly = False And kfat = True And kHold = True Then
                t = 0
                JumpTimer.Stop()
                kFall = False
                kOn = True
                kJump = False
                rKirby.Y = b4.Y - kHeight + 8
                kPosY = b4.Y - kHeight + 8
            ElseIf rDetect.IntersectsWith(b5) And rDetect.Y <= b5.Y + 50 And kFly = False And kfat = True And kHold = True Then
                t = 0
                JumpTimer.Stop()
                kFall = False
                kOn = True
                kJump = False
                rKirby.Y = b5.Y - kHeight + 8
                kPosY = b5.Y - kHeight + 8
            ElseIf rDetect.IntersectsWith(b6) And rDetect.Y <= b6.Y + 50 And kFly = False And kfat = True And kHold = True Then
                t = 0
                JumpTimer.Stop()
                kFall = False
                kOn = True
                kJump = False
                rKirby.Y = b6.Y - kHeight + 8
                kPosY = b6.Y - kHeight + 8
            ElseIf rDetect.IntersectsWith(b7) And rDetect.Y <= b7.Y + 50 And kFly = False And kfat = True And kHold = True Then
                t = 0
                JumpTimer.Stop()
                kFall = False
                kOn = True
                kJump = False
                rKirby.Y = b7.Y - kHeight + 8
                kPosY = b7.Y - kHeight + 8
            End If

            'If Kirby does not intersect anything ----------------------------------------------------------------------------------------------
            If kFall = True Or kMidA = True Then
                kOn = False
            End If

            If Not rKirby.IntersectsWith(b1) And Not rKirby.IntersectsWith(b2) And Not rKirby.IntersectsWith(b3) And Not rKirby.IntersectsWith(b4) And Not rKirby.IntersectsWith(b5) And Not rKirby.IntersectsWith(b6) And Not rKirby.IntersectsWith(b7) Or rKirby.IntersectsWith(b3) And rKirby.Y >= b3.Y And Not rKirby.IntersectsWith(b1) Then
                kMidA = True
            Else
                kMidA = False
            End If

            'If Kirby Interacts with Star ------------------------------------------------------------------------------------------------------
            If screen = 1 And rKirby.IntersectsWith(i1) Then
                lives = 6
                rKirby.X = 100
                rKirby.Y = 100
                kPosY = 100
                ac = 0
                score += 1000
                RecPosY = 0

                kRight = False
                kUp = False
                kLeft = False
                kfat = False
                kSuck = False
                kShoot = False
                kHold = False
                KConsume = False
                kPreFly = True
                kFly = False
                kRevert = False
                kFace = True
                kMidA = False
                kJump = False

                kCol = 0
                kRow = 0

                kNorm = True
                kTCols = 4
                kTRows = 4

                kHeight = kSheet.Height / kTCols
                kWidth = kSheet.Width / kTRows
                kPosY += 30
                rKirby = New Rectangle(rKirby.X, kPosY, kWidth, kHeight)

                BGPosX = 0
                RecPosX = 0

                kStart = False
                screen = 2
            End If
        End If

        'Screen 2 Intersections ----------------------------------------------------------------------------------------------------------------
        If screen = 2 Then

            'if Kirby Lands on Platform --------------------------------------------------------------------------------------------------------
            If kOn = True And kFly = False And kfat = False And kRevert = False Then
                If kRight = False And kLeft = False And kfat = False Then
                    kRow = 0
                    kCol = 0
                ElseIf kRight = True And kfat = False Then
                    kRow = 1
                    kStart = True
                ElseIf kLeft = True And kfat = False Then
                    kRow = 2
                    kStart = True
                End If
            End If

            'If Kirby Doesnt Intersect with Anything (Animation) -------------------------------------------------------------------------------
            If kFall = True And kFly = False And kfat = False Or kMidA = True And kFly = False And kfat = False Then
                kRow = 3
                kCol = 0
                kOn = False
            End If

            'If Kirby runs into the platform (Walls)... ----------------------------------------------------------------------------------------
            If rKirby.IntersectsWith(b8) And rDetect.Y >= b8.Y And rDetect.Y < b8.Y + b8.Height And kLeft = True And rDetect.X >= b8.X + b8.Width - 50 Then
                kVelX = 0
                kLeft = False
            ElseIf rKirby.IntersectsWith(b9) And rDetect.Y >= b9.Y And rDetect.Y < b9.Y + b9.Height And kRight = True And rDetect.X >= b9.X + 50 Then
                kVelX = 0
                kRight = False
            ElseIf rKirby.IntersectsWith(b10) And rDetect.Y >= b10.Y And rDetect.Y < b10.Y + b10.Height And kLeft = True And rDetect.X >= b10.X + b10.Width - 50 Then
                kVelX = 0
                kLeft = False
            ElseIf rKirby.IntersectsWith(b11) And rDetect.Y >= b11.Y And rDetect.Y < b11.Y + b11.Height And kRight = True And rDetect.X >= b11.X + 50 Then
                kVelX = 0
                kRight = False
            ElseIf rKirby.IntersectsWith(b12) And rDetect.Y >= b12.Y And kRight = True And rDetect.X <= b12.X + 50 Then
                kVelX = 0
                kRight = False
            ElseIf kRight = True Then
                kVelX = 4
                rKirby.X += kVelX
                kStart = True
            ElseIf kLeft = True Then
                kVelX = 4
                rKirby.X -= kVelX
                kStart = True
            End If

            If rKirby.IntersectsWith(b12) And rDetect.Y - 30 >= b7.Y And rDetect.X >= b12.X + b12.Width - 50 Then
                rKirby.X = b12.X + b12.Width - 1
            End If

            'If Kirby is on the platform (Not Flying)... ---------------------------------------------------------------------------------------
            If rDetect.IntersectsWith(b8) And rDetect.Y <= b8.Y + 50 And kFly = False And kHold = False Then
                kJump = False
                JumpTimer.Stop()
                rKirby.Y = b8.Y - kHeight + 6
                kPosY = b8.Y - kHeight + 6
                t = 0
                kFall = False
                kOn = True
            ElseIf rDetect.IntersectsWith(b9) And rDetect.Y <= b9.Y + 50 And kFly = False And kHold = False Then
                kJump = False
                JumpTimer.Stop()
                rKirby.Y = b9.Y - kHeight + 6
                kPosY = b9.Y - kHeight + 6
                t = 0
                kFall = False
                kOn = True
            ElseIf rDetect.IntersectsWith(b10) And rDetect.Y <= b10.Y + 50 And kFly = False And kHold = False Then
                kJump = False
                JumpTimer.Stop()
                rKirby.Y = b10.Y - kHeight + 6
                kPosY = b10.Y - kHeight + 6
                t = 0
                kFall = False
                kOn = True
            ElseIf rDetect.IntersectsWith(b11) And rDetect.Y <= b11.Y + 50 And kFly = False And kHold = False Then
                kJump = False
                JumpTimer.Stop()
                rKirby.Y = b11.Y - kHeight + 6
                kPosY = b11.Y - kHeight + 6
                t = 0
                kFall = False
                kOn = True
            End If

            'If Kirby Doesnt Intersect with Anything -------------------------------------------------------------------------------------------
            If Not rDetect.IntersectsWith(b8) And Not rDetect.IntersectsWith(b9) And Not rDetect.IntersectsWith(b10) And Not rDetect.IntersectsWith(b11) And Not rDetect.IntersectsWith(b13) Then
                kMidA = True
            Else
                kMidA = False
            End If

            'If Kirby Lands on the Ground ------------------------------------------------------------------------------------------------------
            If kLand = False And RecPosY <= -1170 And rKirby.Y >= 350 And kPosY >= 350 Then
                kLand = True
            End If
        End If

    End Sub
    Private Sub Mvmnt_Tick(sender As System.Object, e As System.EventArgs) Handles Mvmnt.Tick

        'Movement on Screen 1/2 ----------------------------------------------------------------------------------------------------------------
        If screen = 1 Or screen = 2 Then
            'ATTACK ----------------------------------------------------------------------------------------------------------------------------
            kAtkDis = rAtk.X - kFirstX
            If kAirAtk = True Then
                rAtk.X += kAtkVel
            End If
            If kAtkDis >= 250 Then
                kAirAtk = False
                rAtk.Y += 1000
            ElseIf kAtkDis <= -250 Then
                kAirAtk = False
                rAtk.Y += 1000
            End If

            kAtkDis = rAtk.X - kFirstX
            If kShoot = True And KConsume = False Then
                rAtk.X += kAtkVel
            End If
            If kAtkDis >= 300 Then
                kShoot = False
                rAtk.Y += 1000
            ElseIf kAtkDis <= -300 Then
                kShoot = False
                rAtk.Y += 1000
            End If

            'KIRBY -----------------------------------------------------------------------------------------------------------------------------
            'Dont Go Off of Stage --------------------------------------------------------------------------------------------------------------
            If rKirby.Y > 350 Then
                kPosY = 350
                rKirby.Y = 350
                rDetect.Y = 350 + 70
                kPosY = 350
            ElseIf rKirby.Y >= 320 And kFly = True Or rKirby.Y >= 320 And kfat = True Then
                rKirby.Y = 320
                kPosY = 320
                kMidA = False
            End If

            'Mid Air (Gravity) -----------------------------------------------------------------------------------------------------------------
            If kMidA = True And kFlyAtk = False And kFly = False And kJump = False Then
                kOn = False
                kFall = True
                kJump = True
                JumpTimer.Start()
            End If

            'Detect ----------------------------------------------------------------------------------------------------------------------------
            If kFly = False And kfat = False And screen = 1 Then
                rDetect = New Rectangle(rKirby.X + 9, rKirby.Y + 70, 75, 10)
            ElseIf kFly = False And kfat = False And screen = 2 Then
                rDetect = New Rectangle(rKirby.X + 9, rKirby.Y + 75, 50, 10)
            ElseIf kFly = True Then
                rDetect = New Rectangle(rKirby.X, rKirby.Y + 101, kWidth, 10)
            ElseIf kfat = True Then
                rDetect = New Rectangle(rKirby.X + 10, rKirby.Y + 101, kWidth - 20, 10)
            End If

            'Move Kirby If True ----------------------------------------------------------------------------------------------------------------
            If kUp = True And kPosY >= 0 And rKirby.Y >= 0 And kFly = True And kPreFly = False And kFlyAtk = False And kCol > 2 And kCol < 6 Then
                kVelY = 5
                kPosY -= kVelY
                rKirby.Y = kPosY
            ElseIf kUp = True And kPosY >= 0 And rKirby.Y >= 0 And kFly = True And kPreFly = False And kFlyAtk = False Then
                kVelY = 5
                kPosY -= kVelY
                rKirby.Y = kPosY
            ElseIf kPosY <= 0 Or rKirby.Y <= 0 Then
                kVelY = 0
            End If

            'If Kirby is on this x, then -------------------------------------------------------------------------------------------------------
            If rKirby.X <= -5 Then
                rKirby.X = -5
            End If

            'Screen 1 Movement -----------------------------------------------------------------------------------------------------------------
            If screen = 1 Then
                b1 = New Rectangle(RecPosX, 431, 13000, 100)
                b2 = New Rectangle(RecPosX + 1300, 360, 650, 75)
                b3 = New Rectangle(RecPosX + 2530, 140, 145, 300)
                b4 = New Rectangle(RecPosX + 3545, 360, 645, 70)
                b5 = New Rectangle(RecPosX + 3620, 290, 505, 70)
                b6 = New Rectangle(RecPosX + 5280, 360, 360, 70)
                b7 = New Rectangle(RecPosX + 5425, 285, 360, 75)

                i1 = New Rectangle(RecPosX + 5675, 170, 100, 100)

                'BG Movement -------------------------------------------------------------------------------------------------------------------
                If kRight = True And rKirby.X >= 400 And RecPosX >= -5300 Then
                    rKirby.X = 400
                    BGPosX -= 4
                    RecPosX -= 4
                    kStart = True
                End If
            End If

            'Screen 2 Movement -----------------------------------------------------------------------------------------------------------------
            If screen = 2 Then

                b8 = New Rectangle(0, RecPosY + 210, 490, 70)
                b9 = New Rectangle(560, RecPosY + 210, 200, 70)
                b10 = New Rectangle(0, RecPosY + 490, 210, 70)
                b11 = New Rectangle(280, RecPosY + 490, 415, 70)
                b12 = New Rectangle(480, RecPosY + 500, 200, 1800)
                b13 = New Rectangle(0, RecPosY + 1610, 700, 100)

                rTree = New Rectangle(480, RecPosY + 500, 200, 1000)
                rTFace = New Rectangle(0, BGPosY + 700, treeFace1.Width, treeFace2.Height)

                'Boss Attack Vel ---------------------------------------------------------------------------------------------------------------
                For tc As Integer = 0 To tCreate - 1
                    rTreeAtk(tc).X += tVelX(tc)
                    rTreeAtk(tc).Y += tVelY(tc)
                Next

                'Apple Attack Vel --------------------------------------------------------------------------------------------------------------
                If AppleSpawn = True Then
                    rApple.Y += aVelY
                End If

                'BG Movement -------------------------------------------------------------------------------------------------------------------
                If rKirby.Y >= 350 And RecPosY >= -1175 Then
                    rKirby.Y = 350
                    kPosY = 350
                    BGPosY -= 20
                    RecPosY -= 20
                    kRow = 3
                    kCol = 0
                    kStart = False
                    rKirby.Y = 350
                    kPosY = 350
                End If

                'Dont Let Kirby Move Past Screen -----------------------------------------------------------------------------------------------
                If rKirby.X + rKirby.Width > Me.Width Then
                    rKirby.X = Me.Width - rKirby.Width
                End If
            End If
        End If

        Me.Refresh()

    End Sub
    Private Sub JumpTimer_Tick(sender As System.Object, e As System.EventArgs) Handles JumpTimer.Tick

        'Jump ----------------------------------------------------------------------------------------------------------------------------------
        If screen = 1 Or 2 Then
            If v2 > 20 Then
                v2 = 20
            End If

            'Float Down ------------------------------------------------------------------------------------------------------------------------
            If kFly = True And kUp = False And kfat = False Then
                rKirby.Y = kPosY
                kVelY = 2
                kPosY += kVelY
            End If

            ''Call on Jump Code ----------------------------------------------------------------------------------------------------------------
            If kJump = True And kFly = False And kPreFly = True Then
                Jump()

                rKirby.Y = kPosY
                If kfat = False Then
                    kStart = False
                ElseIf kfat = True Then
                    kStart = True
                End If
                kJump = True

                'If Kirby Lands, then ----------------------------------------------------------------------------------------------------------
                If kPosY >= 320 And kfat = True Or kPosY >= 320 And kFly = True Then
                    kPosY = 320
                    t = 0
                    kJump = False

                    kFall = False
                    Me.Refresh()
                    JumpTimer.Stop()

                ElseIf kPosY >= 350 And kfat = False And kFly = False And kMidA = False Then
                    kPosY = 350
                    t = 0
                    kJump = False
                    If kRight = False And kLeft = False And kfat = False Then
                        kRow = 0
                        kCol = 0
                    ElseIf kRight = True And kfat = False Then
                        kRow = 1
                        kStart = True
                    ElseIf kLeft = True And kfat = False Then
                        kRow = 2
                        kStart = True
                    End If
                    kFall = False
                    Me.Refresh()
                    JumpTimer.Stop()
                End If
            End If
        End If

    End Sub
#End Region
#Region "Controls"
    Private Sub Form1_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        'Screen 0 Controls ---------------------------------------------------------------------------------------------------------------------
        If screen = 0 Then
            If e.KeyCode = Keys.A Then

                score = 0

                'KIRBY -------------------------------------------------------------------------------------------------------------------------
                lives = 6
                tLives = 3

                kRow = 0
                kCol = 0

                kTCols = 4
                kTRows = 4

                kNorm = True
                kStart = False
                kHeight = kSheet.Height / kTCols
                kWidth = kSheet.Width / kTRows
                kPosY = 350

                JumpTimer.Stop()

                kRight = False
                kLeft = False
                kDown = False
                kUp = False
                kFly = False
                kfat = False
                KConsume = False
                kShoot = False
                kJump = False
                kPreFly = True

                kFall = False
                kOn = False
                kFlyAtk = False
                kMidA = False
                kSuck = False
                kRevert = False
                kHold = False
                kLand = False
                count = 0

                'Rectangles --------------------------------------------------------------------------------------------------------------------
                b1 = New Rectangle(RecPosX, 431, 13000, 100)
                b2 = New Rectangle(RecPosX + 1300, 360, 650, 75)
                b3 = New Rectangle(RecPosX + 2530, 140, 145, 300)
                b4 = New Rectangle(RecPosX + 3545, 360, 645, 70)
                b5 = New Rectangle(RecPosX + 3620, 290, 505, 70)
                b6 = New Rectangle(RecPosX + 5280, 360, 360, 70)
                b7 = New Rectangle(RecPosX + 5425, 285, 360, 75)

                i1 = New Rectangle(RecPosX + 5675, 170, 100, 100)

                BGPosX = 0
                BGPosY = 0
                RecPosX = 0
                RecPosY = 0

                rAtk = New Rectangle(-1000, -1000, kAA.Width, kAA.Height)
                rKirby = New Rectangle(300, kPosY, kWidth, kHeight)

                For tc As Integer = 0 To tCreate - 1
                    If Not screen = 2 Or Not RecPosY <= -1170 Then
                        rTreeAtk(tc) = New Rectangle(1000, 1000, 0, 0)
                    End If
                Next

                ac = 0
                tc = 0
                create = 0
                tCreate = 0

                screen = 1
            End If
        End If

        'Screen 0 Controls ---------------------------------------------------------------------------------------------------------------------
        If screen = 3 Then
            If Winner = False Then
                If e.KeyCode = Keys.Up Then
                    rblock = New Rectangle(200, 180, 20, 20)
                ElseIf e.KeyCode = Keys.Down Then
                    rblock = New Rectangle(200, 250, 20, 20)
                End If
                If rblock.Y = 180 And e.KeyCode = Keys.A Then

                    score = 0

                    'KIRBY ---------------------------------------------------------------------------------------------------------------------
                    lives = 6
                    tLives = 3

                    kRow = 0
                    kCol = 0

                    kTCols = 4
                    kTRows = 4

                    kNorm = True
                    kStart = False
                    kHeight = kSheet.Height / kTCols
                    kWidth = kSheet.Width / kTRows
                    kPosY = 350

                    JumpTimer.Stop()

                    kRight = False
                    kLeft = False
                    kDown = False
                    kUp = False
                    kFly = False
                    kfat = False
                    KConsume = False
                    kShoot = False
                    kJump = False
                    kPreFly = True

                    kFall = False
                    kOn = False
                    kFlyAtk = False
                    kMidA = False
                    kSuck = False
                    kRevert = False
                    kHold = False
                    kLand = False
                    count = 0

                    'Rectangles ----------------------------------------------------------------------------------------------------------------
                    b1 = New Rectangle(RecPosX, 431, 13000, 100)
                    b2 = New Rectangle(RecPosX + 1300, 360, 650, 75)
                    b3 = New Rectangle(RecPosX + 2530, 140, 145, 300)
                    b4 = New Rectangle(RecPosX + 3545, 360, 645, 70)
                    b5 = New Rectangle(RecPosX + 3620, 290, 505, 70)
                    b6 = New Rectangle(RecPosX + 5280, 360, 360, 70)
                    b7 = New Rectangle(RecPosX + 5425, 285, 360, 75)

                    i1 = New Rectangle(RecPosX + 5675, 170, 100, 100)

                    BGPosX = 0
                    BGPosY = 0
                    RecPosX = 0
                    RecPosY = 0

                    rAtk = New Rectangle(-1000, -1000, kAA.Width, kAA.Height)
                    rKirby = New Rectangle(300, kPosY, kWidth, kHeight)

                    For tc As Integer = 0 To tCreate - 1
                        If Not screen = 2 Or Not RecPosY <= -1170 Then
                            rTreeAtk(tc) = New Rectangle(1000, 1000, 0, 0)
                        End If
                    Next

                    ac = 0
                    tc = 0
                    create = 0
                    tCreate = 0

                    screen = 1
                End If
                If rblock.Y = 250 And e.KeyCode = Keys.A Then
                    screen = 0
                End If

            ElseIf Winner = True Then
                If rblock.Y = 165 And e.KeyCode = Keys.A Then
                    screen = 0
                    Winner = False
                End If
            End If
        End If

        'Screen 1/2 Controls -------------------------------------------------------------------------------------------------------------------
        If screen = 1 Or screen = 2 Then
            'Kirby Basic Controls --------------------------------------------------------------------------------------------------------------
            If e.KeyCode = Keys.Right And kFly = False And kfat = False And kSuck = False And kHold = False And KConsume = False And kRevert = False Then
                kFace = True
                kStart = True
                If kStart = True Then
                    kRight = True
                    kLeft = False
                    If kJump = False Then
                        kRow = 1
                    End If
                End If
            ElseIf e.KeyCode = Keys.Right And kFly = True Or e.KeyCode = Keys.Right And kfat = True And kSuck = False And kHold = True And kRevert = False Then
                kFace = True
                kRight = True
                kStart = True
            ElseIf e.KeyCode = Keys.Left And kFly = False And kfat = False And kSuck = False And kHold = False And kRevert = False Then
                kFace = False
                kStart = True
                If kStart = True Then
                    kLeft = True
                    kRight = False
                    If kJump = False Then
                        kRow = 2
                    End If
                End If
            ElseIf e.KeyCode = Keys.Left And kFly = True Or e.KeyCode = Keys.Left And kfat = True And kSuck = False And kHold = True And kRevert = False Then
                kFace = False
                kLeft = True
                kStart = True
            ElseIf e.KeyCode = Keys.A And kFly = False And kfat = False And kSuck = False And kHold = False And screen = 1 And kRevert = False Then
                kStart = False
                kFly = False
                kJump = True
                If kStart = False Then
                    kRow = 3
                    kCol = 0
                    If count > 0 Then
                        count = 0
                    End If
                    JumpTimer.Start()
                End If
            ElseIf e.KeyCode = Keys.A And kFly = False And kfat = True And kSuck = False And kHold = True And screen = 1 And kRevert = False Then
                kFly = False
                kJump = True
                JumpTimer.Start()
            ElseIf e.KeyCode = Keys.A And kFly = False And kfat = False And kSuck = False And kHold = False And screen = 2 And RecPosY <= -1170 And kRevert = False Then
                kStart = False
                kFly = False
                kJump = True
                If kStart = False Then
                    kRow = 3
                    kCol = 0
                    If count > 0 Then
                        count = 0
                    End If
                    JumpTimer.Start()
                End If
            ElseIf e.KeyCode = Keys.A And kFly = False And kfat = True And kSuck = False And kHold = True And screen = 2 And RecPosY <= -1170 And kRevert = False Then
                kFly = False
                kJump = True
                JumpTimer.Start()
            End If

            'Kirby Fly Controls ----------------------------------------------------------------------------------------------------------------
            If e.KeyCode = Keys.Up And kPreFly = True And kfat = False And screen = 1 Then
                kTRows = 1
                kTCols = 7
                kStart = True
                If kStart = True Then
                    kNorm = False
                    kFly = True
                    kUp = True
                    kfat = False
                    kHeight = kFloat.Height / kTRows
                    kWidth = kFloat.Width / kTCols
                    kRow = 0
                    kCol = 0
                    kPosY -= 30
                    count = 0
                    rKirby = New Rectangle(rKirby.X, kPosY, kWidth, kHeight)
                    kStart = True
                    kPreFly = False
                    JumpTimer.Start()
                End If
            ElseIf e.KeyCode = Keys.Up And kFly = True And kPreFly = False And kFlyAtk = False And screen = 1 Then
                kUp = True
            ElseIf e.KeyCode = Keys.S And kFly = True And kCol > 2 And kCol < 5 And kPreFly = False And screen = 1 Then
                kFlyAtk = True
                kAirAtk = True
                rKirby.X += 5
                count = 5
                kCol = 5
                AirAttack()
            ElseIf e.KeyCode = Keys.Up And kPreFly = True And kfat = False And screen = 2 And RecPosY <= -1170 Then
                kTRows = 1
                kTCols = 7
                kStart = True
                If kStart = True Then
                    kNorm = False
                    kFly = True
                    kUp = True
                    kfat = False
                    kHeight = kFloat.Height / kTRows
                    kWidth = kFloat.Width / kTCols
                    kRow = 0
                    kCol = 0
                    kPosY -= 30
                    count = 0
                    rKirby = New Rectangle(rKirby.X, kPosY, kWidth, kHeight)
                    kStart = True
                    kPreFly = False
                    JumpTimer.Start()
                End If
            ElseIf e.KeyCode = Keys.Up And kFly = True And kPreFly = False And kFlyAtk = False And screen = 2 And RecPosY <= -1170 Then
                kUp = True
            ElseIf e.KeyCode = Keys.S And kFly = True And kCol > 2 And kCol < 5 And kPreFly = False And screen = 2 And RecPosY <= -1170 Then
                kFlyAtk = True
                kAirAtk = True
                rKirby.X += 5
                count = 5
                kCol = 5
                AirAttack()
            End If

            'Kirby Fat Controls ----------------------------------------------------------------------------------------------------------------
            If e.KeyCode = Keys.S And kFly = False And kSuck = False And kHold = False And screen = 1 Then
                kTRows = 1
                kTCols = 7
                kStart = True
                If kStart = True Then
                    kfat = True
                    kSuck = True
                    kRight = False
                    kLeft = False
                    kHeight = kFloat.Height / kTRows
                    kWidth = kFloat.Width / kTCols
                    kRow = 0
                    kCol = 0
                    kPosY -= 30
                    rKirby = New Rectangle(rKirby.X, kPosY, kWidth, kHeight)
                    kStart = True
                End If
            ElseIf e.KeyCode = Keys.S And kfat = True And kFly = False And kSuck = False And kHold = True And screen = 1 Then
                kShoot = True
                kHold = False
                kSuck = False
                KConsume = False
                count = 4
                kCol = 4
                FatAttack()
            ElseIf e.KeyCode = Keys.Down And kfat = True And kFly = False And kSuck = False And kHold = True Then
                score += 700
                kHold = False
                kShoot = False
                kFly = False
                kRight = False
                kLeft = False
                kUp = False
                kJump = False
                KConsume = True
            ElseIf e.KeyCode = Keys.S And kFly = False And kSuck = False And kHold = False And screen = 2 And RecPosY <= -1170 Then
                kTRows = 1
                kTCols = 7
                kStart = True
                If kStart = True Then
                    kfat = True
                    kSuck = True
                    kRight = False
                    kLeft = False
                    kHeight = kFloat.Height / kTRows
                    kWidth = kFloat.Width / kTCols
                    kRow = 0
                    kCol = 0
                    kPosY -= 30
                    rKirby = New Rectangle(rKirby.X, kPosY, kWidth, kHeight)
                    kStart = True
                End If
            ElseIf e.KeyCode = Keys.S And kfat = True And kFly = False And kSuck = False And kHold = True And screen = 2 And RecPosY <= -1170 Then
                kShoot = True
                kHold = False
                kSuck = False
                KConsume = False
                count = 4
                kCol = 4
                FatAttack()
            ElseIf e.KeyCode = Keys.Down And kfat = True And kFly = False And kSuck = False And kHold = True And screen = 2 And RecPosY <= -1170 Then
                score += 700
                kHold = False
                kShoot = False
                kFly = False
                kRight = False
                kLeft = False
                kUp = False
                kJump = False
                KConsume = True
            End If
        End If

    End Sub
    Private Sub Form1_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        'Kirby Still (Screen = 1) --------------------------------------------------------------------------------------------------------------
        If screen = 1 Then
            If e.KeyCode = Keys.S And kfat = True And kSuck = True And kHold = False And kCol = 1 Then
                kStart = False
                kSuck = False
                kCol = 0
                kRevert = True
            End If
            If e.KeyCode = Keys.Right And kFly = False And kfat = False And kSuck = False And kHold = False Then
                kTCols = 4
                kTRows = 4
                kCol = 0
                kRight = False
                kStart = False
                count = 0
            ElseIf e.KeyCode = Keys.Right And kfat = True And kSuck = False Then
                kRight = False
                kStart = False
            ElseIf e.KeyCode = Keys.Right And kFly = True And kSuck = False And kHold = False Then
                kRight = False
            ElseIf e.KeyCode = Keys.Left And kFly = False And kfat = False And kSuck = False And kHold = False Then
                kTCols = 4
                kTRows = 4
                kLeft = False
                kStart = False
                count = 0
            ElseIf e.KeyCode = Keys.Left And kfat = True And kSuck = False Then
                kLeft = False
                kStart = False
            ElseIf e.KeyCode = Keys.Left And kFly = True And kSuck = False And kHold = False Then
                kLeft = False
            ElseIf e.KeyCode = Keys.A And kFly = False And kFly = False And kfat = False And kSuck = False And kHold = False Then
                kTCols = 4
                kTRows = 4
                kStart = False
                count = 0
            ElseIf e.KeyCode = Keys.Up And kFly = True And kSuck = False And kHold = False Then
                kUp = False
            End If
        End If

        'Kirby Still (Screen = 2) --------------------------------------------------------------------------------------------------------------
        If screen = 2 Then
            If e.KeyCode = Keys.S And kfat = True And kSuck = True And kHold = False And kCol = 1 And RecPosY <= -1170 Then
                kStart = False
                kSuck = False
                kCol = 0
                kRevert = True
            End If

            If e.KeyCode = Keys.Right And kFly = False And kfat = False And kSuck = False And kHold = False Then
                kTCols = 4
                kTRows = 4
                kRight = False
                kStart = False
                count = 0
            ElseIf e.KeyCode = Keys.Right And kfat = True And kSuck = False Then
                kRight = False
                kStart = False
            ElseIf e.KeyCode = Keys.Right And kFly = True And kSuck = False And kHold = False Then
                kRight = False
            ElseIf e.KeyCode = Keys.Left And kFly = False And kfat = False And kSuck = False And kHold = False Then
                kTCols = 4
                kTRows = 4
                kLeft = False
                kStart = False
                count = 0
            ElseIf e.KeyCode = Keys.Left And kfat = True And kSuck = False Then
                kLeft = False
                kStart = False
            ElseIf e.KeyCode = Keys.Left And kFly = True And kSuck = False And kHold = False Then
                kLeft = False
            ElseIf e.KeyCode = Keys.A And kFly = False And kFly = False And kfat = False And kSuck = False And kHold = False And RecPosY <= -1170 Then
                kTCols = 4
                kTRows = 4
                kStart = False
                count = 0
            ElseIf e.KeyCode = Keys.Up And kFly = True And kSuck = False And kHold = False Then
                kUp = False
            End If

            If e.KeyCode = Keys.S And kfat = True And kSuck = True And kHold = False And kCol = 1 Then
                kStart = False
                kSuck = False
                kCol = 0
                kRevert = True
            End If
        End If
    End Sub
#End Region
End Class
