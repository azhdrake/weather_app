namespace WeatherApp
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.pbWeatherImage = new System.Windows.Forms.PictureBox();
      this.lblWeatherText = new System.Windows.Forms.Label();
      this.txtCity = new System.Windows.Forms.TextBox();
      this.txtState = new System.Windows.Forms.TextBox();
      this.btbGetWeather = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.pbWeatherImage)).BeginInit();
      this.SuspendLayout();
      // 
      // pbWeatherImage
      // 
      this.pbWeatherImage.Location = new System.Drawing.Point(-1, 124);
      this.pbWeatherImage.Name = "pbWeatherImage";
      this.pbWeatherImage.Size = new System.Drawing.Size(803, 456);
      this.pbWeatherImage.TabIndex = 0;
      this.pbWeatherImage.TabStop = false;
      // 
      // lblWeatherText
      // 
      this.lblWeatherText.Location = new System.Drawing.Point(196, 170);
      this.lblWeatherText.Name = "lblWeatherText";
      this.lblWeatherText.Size = new System.Drawing.Size(425, 205);
      this.lblWeatherText.TabIndex = 99;
      // 
      // txtCity
      // 
      this.txtCity.Location = new System.Drawing.Point(26, 65);
      this.txtCity.MaxLength = 50;
      this.txtCity.Name = "txtCity";
      this.txtCity.Size = new System.Drawing.Size(189, 31);
      this.txtCity.TabIndex = 0;
      // 
      // txtState
      // 
      this.txtState.Location = new System.Drawing.Point(283, 65);
      this.txtState.MaxLength = 13;
      this.txtState.Name = "txtState";
      this.txtState.Size = new System.Drawing.Size(189, 31);
      this.txtState.TabIndex = 1;
      // 
      // btbGetWeather
      // 
      this.btbGetWeather.Location = new System.Drawing.Point(558, 58);
      this.btbGetWeather.Name = "btbGetWeather";
      this.btbGetWeather.Size = new System.Drawing.Size(144, 44);
      this.btbGetWeather.TabIndex = 2;
      this.btbGetWeather.Text = "Get Weather";
      this.btbGetWeather.UseVisualStyleBackColor = true;
      this.btbGetWeather.Click += new System.EventHandler(this.btbGetWeather_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(21, 27);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(49, 25);
      this.label1.TabIndex = 5;
      this.label1.Text = "City";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(278, 27);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(62, 25);
      this.label2.TabIndex = 6;
      this.label2.Text = "State";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 580);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btbGetWeather);
      this.Controls.Add(this.txtState);
      this.Controls.Add(this.txtCity);
      this.Controls.Add(this.lblWeatherText);
      this.Controls.Add(this.pbWeatherImage);
      this.Name = "Form1";
      this.Text = "Form1";
      ((System.ComponentModel.ISupportInitialize)(this.pbWeatherImage)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox pbWeatherImage;
    private System.Windows.Forms.Label lblWeatherText;
    private System.Windows.Forms.TextBox txtCity;
    private System.Windows.Forms.TextBox txtState;
    private System.Windows.Forms.Button btbGetWeather;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
  }
}

