namespace HuffmanAlgorithm
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.EncodingButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.LoadFileButton = new System.Windows.Forms.Button();
            this.DecodingButton = new System.Windows.Forms.Button();
            this.TextBoxIO = new System.Windows.Forms.TextBox();
            this.HiLabel = new System.Windows.Forms.Label();
            this.HkLabel = new System.Windows.Forms.Label();
            this.Rilabel = new System.Windows.Forms.Label();
            this.Klabel = new System.Windows.Forms.Label();
            this.OpenTextDialog = new System.Windows.Forms.OpenFileDialog();
            this.Rklabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // EncodingButton
            // 
            this.EncodingButton.Location = new System.Drawing.Point(159, 352);
            this.EncodingButton.Margin = new System.Windows.Forms.Padding(4);
            this.EncodingButton.Name = "EncodingButton";
            this.EncodingButton.Size = new System.Drawing.Size(112, 28);
            this.EncodingButton.TabIndex = 0;
            this.EncodingButton.Text = "Кодировать";
            this.EncodingButton.UseVisualStyleBackColor = true;
            this.EncodingButton.Click += new System.EventHandler(this.EncodingButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(11, 352);
            this.LoadButton.Margin = new System.Windows.Forms.Padding(4);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(140, 28);
            this.LoadButton.TabIndex = 1;
            this.LoadButton.Text = "Загрузить текст";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // LoadFileButton
            // 
            this.LoadFileButton.Location = new System.Drawing.Point(282, 352);
            this.LoadFileButton.Margin = new System.Windows.Forms.Padding(4);
            this.LoadFileButton.Name = "LoadFileButton";
            this.LoadFileButton.Size = new System.Drawing.Size(248, 28);
            this.LoadFileButton.TabIndex = 3;
            this.LoadFileButton.Text = "Загрузить кодированный файл";
            this.LoadFileButton.UseVisualStyleBackColor = true;
            this.LoadFileButton.Click += new System.EventHandler(this.LoadFileButton_Click);
            // 
            // DecodingButton
            // 
            this.DecodingButton.Location = new System.Drawing.Point(539, 352);
            this.DecodingButton.Margin = new System.Windows.Forms.Padding(4);
            this.DecodingButton.Name = "DecodingButton";
            this.DecodingButton.Size = new System.Drawing.Size(122, 28);
            this.DecodingButton.TabIndex = 2;
            this.DecodingButton.Text = "Декодировать";
            this.DecodingButton.UseVisualStyleBackColor = true;
            this.DecodingButton.Click += new System.EventHandler(this.DecodingButton_Click);
            // 
            // TextBoxIO
            // 
            this.TextBoxIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBoxIO.Location = new System.Drawing.Point(13, 14);
            this.TextBoxIO.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxIO.Multiline = true;
            this.TextBoxIO.Name = "TextBoxIO";
            this.TextBoxIO.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxIO.Size = new System.Drawing.Size(650, 333);
            this.TextBoxIO.TabIndex = 4;
            // 
            // HiLabel
            // 
            this.HiLabel.AutoSize = true;
            this.HiLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HiLabel.Location = new System.Drawing.Point(667, 31);
            this.HiLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.HiLabel.MaximumSize = new System.Drawing.Size(180, 0);
            this.HiLabel.Name = "HiLabel";
            this.HiLabel.Size = new System.Drawing.Size(42, 16);
            this.HiLabel.TabIndex = 5;
            this.HiLabel.Text = "H исх";
            // 
            // HkLabel
            // 
            this.HkLabel.AutoSize = true;
            this.HkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HkLabel.Location = new System.Drawing.Point(667, 60);
            this.HkLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.HkLabel.MaximumSize = new System.Drawing.Size(180, 0);
            this.HkLabel.Name = "HkLabel";
            this.HkLabel.Size = new System.Drawing.Size(44, 16);
            this.HkLabel.TabIndex = 6;
            this.HkLabel.Text = "H код";
            // 
            // Rilabel
            // 
            this.Rilabel.AutoSize = true;
            this.Rilabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Rilabel.Location = new System.Drawing.Point(667, 118);
            this.Rilabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Rilabel.MaximumSize = new System.Drawing.Size(180, 0);
            this.Rilabel.Name = "Rilabel";
            this.Rilabel.Size = new System.Drawing.Size(42, 16);
            this.Rilabel.TabIndex = 8;
            this.Rilabel.Text = "R исх";
            // 
            // Klabel
            // 
            this.Klabel.AutoSize = true;
            this.Klabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Klabel.Location = new System.Drawing.Point(667, 89);
            this.Klabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Klabel.MaximumSize = new System.Drawing.Size(180, 0);
            this.Klabel.Name = "Klabel";
            this.Klabel.Size = new System.Drawing.Size(65, 16);
            this.Klabel.TabIndex = 7;
            this.Klabel.Text = "K сжатия";
            // 
            // Rklabel
            // 
            this.Rklabel.AutoSize = true;
            this.Rklabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Rklabel.Location = new System.Drawing.Point(667, 146);
            this.Rklabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Rklabel.MaximumSize = new System.Drawing.Size(180, 0);
            this.Rklabel.Name = "Rklabel";
            this.Rklabel.Size = new System.Drawing.Size(44, 16);
            this.Rklabel.TabIndex = 10;
            this.Rklabel.Text = "R код";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 390);
            this.Controls.Add(this.Rklabel);
            this.Controls.Add(this.Rilabel);
            this.Controls.Add(this.Klabel);
            this.Controls.Add(this.HkLabel);
            this.Controls.Add(this.HiLabel);
            this.Controls.Add(this.TextBoxIO);
            this.Controls.Add(this.LoadFileButton);
            this.Controls.Add(this.DecodingButton);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.EncodingButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Кодирование алгоритмом Хаффмана";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EncodingButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button LoadFileButton;
        private System.Windows.Forms.Button DecodingButton;
        private System.Windows.Forms.TextBox TextBoxIO;
        private System.Windows.Forms.Label HiLabel;
        private System.Windows.Forms.Label HkLabel;
        private System.Windows.Forms.Label Rilabel;
        private System.Windows.Forms.Label Klabel;
        private System.Windows.Forms.OpenFileDialog OpenTextDialog;
        private System.Windows.Forms.Label Rklabel;
    }
}

