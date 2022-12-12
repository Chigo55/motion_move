
namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TrackBar_Value_Label = new System.Windows.Forms.Label();
            this.Threshold_TrackBar = new System.Windows.Forms.TrackBar();
            this.Inposition_Button = new System.Windows.Forms.Button();
            this.End_Limit_Button = new System.Windows.Forms.Button();
            this.Home_Button = new System.Windows.Forms.Button();
            this.Alarm_Button = new System.Windows.Forms.Button();
            this.Image_Convert_button = new System.Windows.Forms.Button();
            this.Contour_Image_Box = new System.Windows.Forms.PictureBox();
            this.Binary_Image_Box = new System.Windows.Forms.PictureBox();
            this.Move_Button = new System.Windows.Forms.Button();
            this.Servo_On_Button = new System.Windows.Forms.Button();
            this.Image_Load_Button = new System.Windows.Forms.Button();
            this.Contour_Image_Label = new System.Windows.Forms.Label();
            this.Binary_Image_Label = new System.Windows.Forms.Label();
            this.Gray_Image_Label = new System.Windows.Forms.Label();
            this.Original_Image_Box = new System.Windows.Forms.PictureBox();
            this.Gray_Image_Box = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Original_Image_Label = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Z_Break_Button = new System.Windows.Forms.Button();
            this.Break_Button = new System.Windows.Forms.Button();
            this.Z_Move_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Threshold_TrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Contour_Image_Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Binary_Image_Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Original_Image_Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gray_Image_Box)).BeginInit();
            this.SuspendLayout();
            // 
            // TrackBar_Value_Label
            // 
            this.TrackBar_Value_Label.AutoSize = true;
            this.TrackBar_Value_Label.Location = new System.Drawing.Point(849, 325);
            this.TrackBar_Value_Label.Name = "TrackBar_Value_Label";
            this.TrackBar_Value_Label.Size = new System.Drawing.Size(71, 15);
            this.TrackBar_Value_Label.TabIndex = 44;
            this.TrackBar_Value_Label.Text = "Threshold";
            // 
            // Threshold_TrackBar
            // 
            this.Threshold_TrackBar.Location = new System.Drawing.Point(836, 343);
            this.Threshold_TrackBar.Maximum = 255;
            this.Threshold_TrackBar.Name = "Threshold_TrackBar";
            this.Threshold_TrackBar.Size = new System.Drawing.Size(277, 56);
            this.Threshold_TrackBar.TabIndex = 43;
            this.Threshold_TrackBar.Scroll += new System.EventHandler(this.Threshold_TrackBar_Scroll);
            // 
            // Inposition_Button
            // 
            this.Inposition_Button.Location = new System.Drawing.Point(836, 536);
            this.Inposition_Button.Name = "Inposition_Button";
            this.Inposition_Button.Size = new System.Drawing.Size(118, 44);
            this.Inposition_Button.TabIndex = 42;
            this.Inposition_Button.Text = "Inposition";
            this.Inposition_Button.UseVisualStyleBackColor = true;
            this.Inposition_Button.Click += new System.EventHandler(this.Inposition_Button_Click);
            // 
            // End_Limit_Button
            // 
            this.End_Limit_Button.Location = new System.Drawing.Point(995, 437);
            this.End_Limit_Button.Name = "End_Limit_Button";
            this.End_Limit_Button.Size = new System.Drawing.Size(118, 44);
            this.End_Limit_Button.TabIndex = 41;
            this.End_Limit_Button.Text = "End_Limit";
            this.End_Limit_Button.UseVisualStyleBackColor = true;
            this.End_Limit_Button.Click += new System.EventHandler(this.End_Limit_Button_Click);
            // 
            // Home_Button
            // 
            this.Home_Button.Location = new System.Drawing.Point(995, 536);
            this.Home_Button.Name = "Home_Button";
            this.Home_Button.Size = new System.Drawing.Size(118, 44);
            this.Home_Button.TabIndex = 40;
            this.Home_Button.Text = "Home";
            this.Home_Button.UseVisualStyleBackColor = true;
            this.Home_Button.Click += new System.EventHandler(this.Home_Button_Click);
            // 
            // Alarm_Button
            // 
            this.Alarm_Button.Location = new System.Drawing.Point(836, 437);
            this.Alarm_Button.Name = "Alarm_Button";
            this.Alarm_Button.Size = new System.Drawing.Size(118, 44);
            this.Alarm_Button.TabIndex = 39;
            this.Alarm_Button.Text = "Alarm";
            this.Alarm_Button.UseVisualStyleBackColor = true;
            this.Alarm_Button.Click += new System.EventHandler(this.Alarm_Button_Click);
            // 
            // Image_Convert_button
            // 
            this.Image_Convert_button.Location = new System.Drawing.Point(995, 49);
            this.Image_Convert_button.Name = "Image_Convert_button";
            this.Image_Convert_button.Size = new System.Drawing.Size(118, 44);
            this.Image_Convert_button.TabIndex = 38;
            this.Image_Convert_button.Text = "Image_Convert";
            this.Image_Convert_button.UseVisualStyleBackColor = true;
            this.Image_Convert_button.Click += new System.EventHandler(this.Image_Convert_button_Click);
            // 
            // Contour_Image_Box
            // 
            this.Contour_Image_Box.BackColor = System.Drawing.Color.White;
            this.Contour_Image_Box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Contour_Image_Box.Location = new System.Drawing.Point(436, 437);
            this.Contour_Image_Box.Name = "Contour_Image_Box";
            this.Contour_Image_Box.Size = new System.Drawing.Size(350, 350);
            this.Contour_Image_Box.TabIndex = 37;
            this.Contour_Image_Box.TabStop = false;
            // 
            // Binary_Image_Box
            // 
            this.Binary_Image_Box.BackColor = System.Drawing.Color.White;
            this.Binary_Image_Box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Binary_Image_Box.Location = new System.Drawing.Point(40, 437);
            this.Binary_Image_Box.Name = "Binary_Image_Box";
            this.Binary_Image_Box.Size = new System.Drawing.Size(350, 350);
            this.Binary_Image_Box.TabIndex = 36;
            this.Binary_Image_Box.TabStop = false;
            // 
            // Move_Button
            // 
            this.Move_Button.Location = new System.Drawing.Point(995, 143);
            this.Move_Button.Name = "Move_Button";
            this.Move_Button.Size = new System.Drawing.Size(118, 44);
            this.Move_Button.TabIndex = 33;
            this.Move_Button.Text = "Move";
            this.Move_Button.UseVisualStyleBackColor = true;
            this.Move_Button.Click += new System.EventHandler(this.Move_Button_Click);
            // 
            // Servo_On_Button
            // 
            this.Servo_On_Button.Location = new System.Drawing.Point(836, 143);
            this.Servo_On_Button.Name = "Servo_On_Button";
            this.Servo_On_Button.Size = new System.Drawing.Size(118, 44);
            this.Servo_On_Button.TabIndex = 32;
            this.Servo_On_Button.Text = "Servo_On";
            this.Servo_On_Button.UseVisualStyleBackColor = true;
            this.Servo_On_Button.Click += new System.EventHandler(this.Servo_On_Button_Click);
            // 
            // Image_Load_Button
            // 
            this.Image_Load_Button.Location = new System.Drawing.Point(836, 49);
            this.Image_Load_Button.Name = "Image_Load_Button";
            this.Image_Load_Button.Size = new System.Drawing.Size(118, 44);
            this.Image_Load_Button.TabIndex = 31;
            this.Image_Load_Button.Text = "Image_Load";
            this.Image_Load_Button.UseVisualStyleBackColor = true;
            this.Image_Load_Button.Click += new System.EventHandler(this.Image_Load_Button_Click);
            // 
            // Contour_Image_Label
            // 
            this.Contour_Image_Label.AutoSize = true;
            this.Contour_Image_Label.Location = new System.Drawing.Point(433, 419);
            this.Contour_Image_Label.Name = "Contour_Image_Label";
            this.Contour_Image_Label.Size = new System.Drawing.Size(105, 15);
            this.Contour_Image_Label.TabIndex = 30;
            this.Contour_Image_Label.Text = "Contour_Image";
            // 
            // Binary_Image_Label
            // 
            this.Binary_Image_Label.AutoSize = true;
            this.Binary_Image_Label.Location = new System.Drawing.Point(37, 419);
            this.Binary_Image_Label.Name = "Binary_Image_Label";
            this.Binary_Image_Label.Size = new System.Drawing.Size(94, 15);
            this.Binary_Image_Label.TabIndex = 29;
            this.Binary_Image_Label.Text = "Binary_Image";
            // 
            // Gray_Image_Label
            // 
            this.Gray_Image_Label.AutoSize = true;
            this.Gray_Image_Label.Location = new System.Drawing.Point(433, 31);
            this.Gray_Image_Label.Name = "Gray_Image_Label";
            this.Gray_Image_Label.Size = new System.Drawing.Size(84, 15);
            this.Gray_Image_Label.TabIndex = 28;
            this.Gray_Image_Label.Text = "Gray_Image";
            // 
            // Original_Image_Box
            // 
            this.Original_Image_Box.BackColor = System.Drawing.Color.White;
            this.Original_Image_Box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Original_Image_Box.Location = new System.Drawing.Point(40, 49);
            this.Original_Image_Box.Name = "Original_Image_Box";
            this.Original_Image_Box.Size = new System.Drawing.Size(350, 350);
            this.Original_Image_Box.TabIndex = 34;
            this.Original_Image_Box.TabStop = false;
            // 
            // Gray_Image_Box
            // 
            this.Gray_Image_Box.BackColor = System.Drawing.Color.White;
            this.Gray_Image_Box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Gray_Image_Box.Location = new System.Drawing.Point(436, 49);
            this.Gray_Image_Box.Name = "Gray_Image_Box";
            this.Gray_Image_Box.Size = new System.Drawing.Size(350, 350);
            this.Gray_Image_Box.TabIndex = 35;
            this.Gray_Image_Box.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Original_Image_Label
            // 
            this.Original_Image_Label.AutoSize = true;
            this.Original_Image_Label.BackColor = System.Drawing.SystemColors.Control;
            this.Original_Image_Label.Location = new System.Drawing.Point(37, 31);
            this.Original_Image_Label.Name = "Original_Image_Label";
            this.Original_Image_Label.Size = new System.Drawing.Size(102, 15);
            this.Original_Image_Label.TabIndex = 27;
            this.Original_Image_Label.Text = "Original_Image";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Z_Break_Button
            // 
            this.Z_Break_Button.Location = new System.Drawing.Point(836, 242);
            this.Z_Break_Button.Name = "Z_Break_Button";
            this.Z_Break_Button.Size = new System.Drawing.Size(118, 44);
            this.Z_Break_Button.TabIndex = 45;
            this.Z_Break_Button.Text = "Z_Break";
            this.Z_Break_Button.UseVisualStyleBackColor = true;
            this.Z_Break_Button.Click += new System.EventHandler(this.Z_Break_Button_Click);
            // 
            // Break_Button
            // 
            this.Break_Button.Location = new System.Drawing.Point(836, 632);
            this.Break_Button.Name = "Break_Button";
            this.Break_Button.Size = new System.Drawing.Size(118, 44);
            this.Break_Button.TabIndex = 46;
            this.Break_Button.Text = "Break";
            this.Break_Button.UseVisualStyleBackColor = true;
            this.Break_Button.Click += new System.EventHandler(this.Break_Button_Click);
            // 
            // Z_Move_Button
            // 
            this.Z_Move_Button.Location = new System.Drawing.Point(995, 242);
            this.Z_Move_Button.Name = "Z_Move_Button";
            this.Z_Move_Button.Size = new System.Drawing.Size(118, 44);
            this.Z_Move_Button.TabIndex = 47;
            this.Z_Move_Button.Text = "Z_Move";
            this.Z_Move_Button.UseVisualStyleBackColor = true;
            this.Z_Move_Button.Click += new System.EventHandler(this.Z_Move_Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 825);
            this.Controls.Add(this.Z_Move_Button);
            this.Controls.Add(this.Break_Button);
            this.Controls.Add(this.Z_Break_Button);
            this.Controls.Add(this.TrackBar_Value_Label);
            this.Controls.Add(this.Threshold_TrackBar);
            this.Controls.Add(this.Inposition_Button);
            this.Controls.Add(this.End_Limit_Button);
            this.Controls.Add(this.Home_Button);
            this.Controls.Add(this.Alarm_Button);
            this.Controls.Add(this.Image_Convert_button);
            this.Controls.Add(this.Contour_Image_Box);
            this.Controls.Add(this.Binary_Image_Box);
            this.Controls.Add(this.Move_Button);
            this.Controls.Add(this.Servo_On_Button);
            this.Controls.Add(this.Image_Load_Button);
            this.Controls.Add(this.Contour_Image_Label);
            this.Controls.Add(this.Binary_Image_Label);
            this.Controls.Add(this.Gray_Image_Label);
            this.Controls.Add(this.Original_Image_Box);
            this.Controls.Add(this.Gray_Image_Box);
            this.Controls.Add(this.Original_Image_Label);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Threshold_TrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Contour_Image_Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Binary_Image_Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Original_Image_Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gray_Image_Box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label TrackBar_Value_Label;
        private System.Windows.Forms.TrackBar Threshold_TrackBar;
        private System.Windows.Forms.Button Inposition_Button;
        private System.Windows.Forms.Button End_Limit_Button;
        private System.Windows.Forms.Button Home_Button;
        private System.Windows.Forms.Button Alarm_Button;
        private System.Windows.Forms.Button Image_Convert_button;
        private System.Windows.Forms.PictureBox Contour_Image_Box;
        private System.Windows.Forms.PictureBox Binary_Image_Box;
        private System.Windows.Forms.Button Move_Button;
        private System.Windows.Forms.Button Servo_On_Button;
        private System.Windows.Forms.Button Image_Load_Button;
        private System.Windows.Forms.Label Contour_Image_Label;
        private System.Windows.Forms.Label Binary_Image_Label;
        private System.Windows.Forms.Label Gray_Image_Label;
        private System.Windows.Forms.PictureBox Original_Image_Box;
        private System.Windows.Forms.PictureBox Gray_Image_Box;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label Original_Image_Label;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Z_Break_Button;
        private System.Windows.Forms.Button Break_Button;
        private System.Windows.Forms.Button Z_Move_Button;
    }
}

