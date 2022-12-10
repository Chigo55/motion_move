using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

// OpenCvSharp 라이브러리 선언
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {  
            InitializeComponent();

            // 정상적으로 AXL 라이브러리가 열리는지 확인
            if (CAXL.AxlOpen(7) == (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            {
                MessageBox.Show("AXL 라이브러리 Open 성공");
            }

            // x, y, z축 설정 초기화
            for (int i = 0; i < 3; i++)
            {
                // level setting
                CAXM.AxmSignalSetServoOnLevel(i, (uint)AXT_MOTION_LEVEL_MODE.HIGH);
                CAXM.AxmSignalSetServoAlarmResetLevel(i, (uint)AXT_MOTION_LEVEL_MODE.HIGH);
                CAXM.AxmSignalSetInpos(i, (uint)AXT_MOTION_LEVEL_MODE.UNUSED);

                // drive setting
                CAXM.AxmMotSetMoveUnitPerPulse(i, 1, 1000);
                CAXM.AxmMotSetPulseOutMethod(i, (uint)AXT_MOTION_PULSE_OUTPUT.TwoCwCcwHigh);
                CAXM.AxmMotSetEncInputMethod(i, (uint)AXT_MOTION_EXTERNAL_COUNTER_INPUT.ObverseSqr4Mode);
                CAXM.AxmMotSetAbsRelMode(i, (uint)AXT_MOTION_ABSREL.POS_REL_MODE);
                CAXM.AxmMotSetProfileMode(i, (uint)AXT_MOTION_PROFILE_MODE.SYM_S_CURVE_MODE);
            }
        }

        // 불러온 이미지 주소 전역 변수 선언
        public string image_path;

        private void Image_Load_Button_Click(object sender, EventArgs e)
        {
            // 이미지를 불러오는데 성공한 경우
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Original_Image_Box.Image = new Bitmap(openFileDialog1.OpenFile());
                Original_Image_Box.SizeMode = PictureBoxSizeMode.Zoom;

                image_path = openFileDialog1.FileName;
            }
            // 이미지를 불러오는데 실패한 경우
            else if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                MessageBox.Show("그림파일을 선택하여 주세요.");
            }
        }

        // 이미지의 외각선을 위한 변수를 전역변수로 선언
        public List<OpenCvSharp.Point[]> new_contours = new List<OpenCvSharp.Point[]>();

        private void Image_Convert_button_Click(object sender, EventArgs e)
        {
            Mat source_image = new Mat(image_path);
            Mat gray_image = new Mat();
            Mat binary_image = new Mat();

            // 이미지를 회색 이미지로 변환
            Cv2.CvtColor(source_image, gray_image, ColorConversionCodes.BGR2GRAY);

            // 이미지를 임계값 처리를 하여 이진화
            Cv2.Threshold(gray_image, binary_image, Threshold_TrackBar.Value, 255, ThresholdTypes.Binary);

            // 이진화한 이미지에서 외각선 검출
            OpenCvSharp.Point[][] contours;
            Cv2.FindContours(binary_image, out contours, out HierarchyIndex[] hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxTC89KCOS);
            Mat contour_image = binary_image.Clone();

            // 외각선 내부의 면적을 계산하여 100이하의 면적을 가진 외각선을 제거
            foreach (OpenCvSharp.Point[] contour in contours)
            {
                double length = Cv2.ArcLength(contour, true);
                if (length > 100)
                {
                    new_contours.Add(contour);
                }
            }

            // 이미지의 외각선을 그리는 함수
            Cv2.DrawContours(contour_image, new_contours, -1, Scalar.Green, 3, LineTypes.AntiAlias);

            // 각 단계별로 처리된 이미지를 PictureBox에 표시
            Gray_Image_Box.Image = BitmapConverter.ToBitmap(gray_image);
            Gray_Image_Box.SizeMode = PictureBoxSizeMode.Zoom;
            Binary_Image_Box.Image = BitmapConverter.ToBitmap(binary_image);
            Binary_Image_Box.SizeMode = PictureBoxSizeMode.Zoom;
            Contour_Image_Box.Image = BitmapConverter.ToBitmap(contour_image);
            Contour_Image_Box.SizeMode = PictureBoxSizeMode.Zoom;
        }

        // 버튼의 On-Off 상태를 알기 위한 변수 선언  
        public int ServoOn, Move_start, Home, ZBreak = 0;
        public int Alarm, EndLimit, Inposition, Break = 0;

        private void Servo_On_Button_Click(object sender, EventArgs e)
        {
            if (ServoOn == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    // x, y, z축의 서보 모터 On
                    CAXM.AxmSignalServoOn(i, 1);

                    // level setting
                    CAXM.AxmSignalSetServoOnLevel(i, (uint)AXT_MOTION_LEVEL_MODE.HIGH);
                    CAXM.AxmSignalSetServoAlarmResetLevel(i, (uint)AXT_MOTION_LEVEL_MODE.HIGH);
                    CAXM.AxmSignalSetInpos(i, (uint)AXT_MOTION_LEVEL_MODE.UNUSED);
                    // drive setting
                    CAXM.AxmMotSetMoveUnitPerPulse(i, 1, 1000);
                    CAXM.AxmMotSetPulseOutMethod(i, (uint)AXT_MOTION_PULSE_OUTPUT.TwoCwCcwHigh);
                    CAXM.AxmMotSetEncInputMethod(i, (uint)AXT_MOTION_EXTERNAL_COUNTER_INPUT.ObverseSqr4Mode);
                    CAXM.AxmMotSetAbsRelMode(i, (uint)AXT_MOTION_ABSREL.POS_REL_MODE);
                    CAXM.AxmMotSetProfileMode(i, (uint)AXT_MOTION_PROFILE_MODE.SYM_S_CURVE_MODE);
                }
                Servo_On_Button.BackColor = Color.LightGreen;
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    // x, y, z축의 서보 모터 Off
                    CAXM.AxmSignalServoOn(i, 0);
                }
                Servo_On_Button.BackColor = Color.LightGray;
            }
            ServoOn = ~ServoOn;
        }

        private void Threshold_TrackBar_Scroll(object sender, EventArgs e)
        {
            // 트랙바를 이용하여 이미지의 이진화 시 임계값 설정
            TrackBar_Value_Label.Text = "Threshold: " + Threshold_TrackBar.Value.ToString();

        }

        private void Move_Button_Click(object sender, EventArgs e)
        {
            int[] lAxis = new int[2];
            uint lPosSize = 2;
            int lCoordinate = 0;
            double Velocity = 200, Accel = 200;
            lAxis[0] = 0;
            lAxis[1] = 1;

            // Queue에 저장된 좌표들을 삭제
            CAXM.AxmContiWriteClear(lCoordinate);
            // 좌표계 축 맵핑 설정
            CAXM.AxmContiSetAxisMap(lCoordinate, lPosSize, lAxis);
            // 절대 좌표 위치 구동
            CAXM.AxmContiSetAbsRelMode(lCoordinate, 0);
            
            if (Move_start == 0)
            {
                Move_Button.BackColor = Color.LightGreen;

                // 외각선 그룹의 갯수 만큼 반복문 실행
                for (int i = 0; i < new_contours.Count; i++)
                {
                    // Queue에 저장된 좌표들을 삭제
                    CAXM.AxmContiWriteClear(lCoordinate);
                    // 초기화한 Queue에 좌표 저장 시작
                    CAXM.AxmContiBeginNode(lCoordinate);

                    // 외각선 안에 있는 좌표의 갯수 만큼 반복문 실햄
                    OpenCvSharp.Point[] position = new_contours[i];
                    for (int j = 0; j < position.Length; j++)
                    {
                        // 외각선의 좌표를 추출하는 코드
                        // 좌표를 문자열 형식으로 변환
                        string position2string = position[j].ToString();
                        // 문자열로 변환된 좌표를 x, y로 구분하여 잘라냄
                        string a = position2string.Substring(position2string.IndexOf("x:") + 2, position2string.IndexOf("y:") - 4);
                        string b = position2string.Substring(position2string.IndexOf("y:") + 2);
                        // 필요한 좌표 이외의 문자열을 없앰
                        string x_string = Regex.Replace(a, @"[^0-9]", "");
                        string y_string = Regex.Replace(b, @"[^0-9]", "");
                        // 추출한 좌표를 double형태로 변환
                        double x = double.Parse(x_string);
                        double y = double.Parse(y_string);
                        // 좌표를 배열에 저장
                        double[] line_position = { x, y };

                        // 외각선의 시작 좌표의 경우에만 먼저 움직이도록 설정
                        if (j == 0)
                        {
                            // 직선 보간 함수
                            CAXM.AxmLineMove(lCoordinate, line_position, Velocity, Accel, Accel);
                            // Queue에 좌표 저장 종료
                            CAXM.AxmContiEndNode(lCoordinate);
                            // 연속 보간 구동 시작
                            CAXM.AxmContiStart(lCoordinate, 0, 0);
                            // 연속 보간 구동이 끝날때 까지 대기
                            timer1.Start();
                            // 구동이 끝나면 z축 하강
                            CAXM.AxmMovePos(2, -200, Velocity, Accel, Accel);
                        }
                        // 시작 좌표 이외의 경우에는 계속 좌표를 저장
                        else
                        {
                            CAXM.AxmLineMove(lCoordinate, line_position, Velocity, Accel, Accel);
                        }
                    }
                    // Queue에 좌표 저장 종료
                    CAXM.AxmContiEndNode(lCoordinate);
                    // 연속 보간 구동 시작
                    CAXM.AxmContiStart(lCoordinate, 0, 0);
                    // 연속 보간 구동이 끝날때 까지 대기
                    timer1.Start();
                }
            }
            else
            {
                Move_Button.BackColor = Color.LightGray;
            }
            Move_start = ~Move_start;
        }

        // 구동 상태를 확인 하기위한 변수
        public uint X_State = 1;
        public uint Y_State = 1;
        public uint Z_State = 1;
        public uint cnt = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            // x, y, z축의 구동 상태 확인
            for (int i = 0; i < 3; i++)
            {
                CAXM.AxmStatusReadInMotion(i, ref X_State);
            }

            // 구동이 끝났을 경우
            if ((X_State | Y_State | Z_State) == 0)
            {
                cnt++;
                X_State = 1;
                Y_State = 1;
                Z_State = 1;
            }

            // 구동이 끝났을 경우 z축의 위치를 초기화
            if (cnt == 1)
            {
                double Velocity = 200, Accel = 200;

                CAXM.AxmMovePos(2, 0, Velocity, Accel, Accel);
                cnt = 0;
            }
        }

        private void Z_Break_Button_Click(object sender, EventArgs e)
        {
            if (ZBreak == 0)
            {
                // z축 범용 출력 2 ON -> Z축 브레이크 해제
                CAXM.AxmSignalWriteOutputBit(2, 2, 1);  
                Z_Break_Button.BackColor = Color.LightGreen;
            }
            else
            {
                // Z축 브레이크 잠김
                CAXM.AxmSignalWriteOutputBit(2, 2, 0);  
                Z_Break_Button.BackColor = Color.LightPink;
            }
            ZBreak = ~ZBreak;
        }

        private void Break_Button_Click(object sender, EventArgs e)
        {
            // 정지 버튼 On
            if (Break == 0)
            {
                int lCoordinate = 0;
                // Queue에 저장된 좌표들을 삭제
                CAXM.AxmContiWriteClear(lCoordinate);

                // 홈 위치로 구동
                for (int i = 0; i < 3; i++)
                {
                    CAXM.AxmHomeSetStart(i);
                }
                Break_Button.BackColor = Color.LightPink;
            }
            else
            {
                Break_Button.BackColor = Color.LightGray;
            }
            Break = ~Break;
        }

        private void Alarm_Button_Click(object sender, EventArgs e)
        {
            if (Alarm == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    // 알람 초기화
                    CAXM.AxmSignalServoAlarmReset(i, 1);
                }
                Alarm_Button.BackColor = Color.LightPink;
            }
            else
            {
                Alarm_Button.BackColor = Color.LightGray;
            }
            Alarm = ~Alarm;
        }

        private void Home_Button_Click(object sender, EventArgs e)
        {
            if (Home == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    // 홈 위치로 구동
                    CAXM.AxmHomeSetStart(i);
                }

                Home_Button.BackColor = Color.LightGreen;
            }
            else
            {
                Home_Button.BackColor = Color.LightGray;
            }
            Home = ~Home;
        }

        private void End_Limit_Button_Click(object sender, EventArgs e)
        {
            if (EndLimit == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    // End_Limit Low 설정
                    CAXM.AxmSignalSetLimit(i, 1, (uint)AXT_MOTION_LEVEL_MODE.LOW, (uint)AXT_MOTION_LEVEL_MODE.LOW);
                }
                End_Limit_Button.BackColor = Color.LightPink;
            }
            else
            {
                End_Limit_Button.BackColor = Color.LightGray;
            }
            EndLimit = ~EndLimit;
        }

        private void Inposition_Button_Click(object sender, EventArgs e)
        {
            if (Inposition == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    // Inposition UNUSED 설정
                    CAXM.AxmSignalSetInpos(i, (uint)AXT_MOTION_LEVEL_MODE.UNUSED);
                }
                Inposition_Button.BackColor = Color.LightPink;
            }
            else
            {
                Inposition_Button.BackColor = Color.LightGray;
            }
            Inposition = ~Inposition;
        }
    }
}