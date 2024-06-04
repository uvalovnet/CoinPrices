namespace CoinPrices
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BinanceLabel = new Label();
            BinancePrice = new Label();
            label3 = new Label();
            BybitPrice = new Label();
            BitgetLabel = new Label();
            BitgetPrice = new Label();
            label1 = new Label();
            KucoinPrice = new Label();
            SetCoin = new ComboBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // BinanceLabel
            // 
            BinanceLabel.AutoSize = true;
            BinanceLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            BinanceLabel.Location = new Point(12, 9);
            BinanceLabel.Name = "BinanceLabel";
            BinanceLabel.Size = new Size(114, 35);
            BinanceLabel.TabIndex = 0;
            BinanceLabel.Text = "Binance:";
            // 
            // BinancePrice
            // 
            BinancePrice.AutoSize = true;
            BinancePrice.Font = new Font("Segoe UI", 15F);
            BinancePrice.Location = new Point(132, 9);
            BinancePrice.Name = "BinancePrice";
            BinancePrice.Size = new Size(0, 35);
            BinancePrice.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label3.Location = new Point(12, 44);
            label3.Name = "label3";
            label3.Size = new Size(84, 35);
            label3.TabIndex = 2;
            label3.Text = "Bybit:";
            // 
            // BybitPrice
            // 
            BybitPrice.AutoSize = true;
            BybitPrice.Font = new Font("Segoe UI", 15F);
            BybitPrice.Location = new Point(132, 44);
            BybitPrice.Name = "BybitPrice";
            BybitPrice.Size = new Size(0, 35);
            BybitPrice.TabIndex = 3;
            // 
            // BitgetLabel
            // 
            BitgetLabel.AutoSize = true;
            BitgetLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            BitgetLabel.Location = new Point(12, 79);
            BitgetLabel.Name = "BitgetLabel";
            BitgetLabel.Size = new Size(94, 35);
            BitgetLabel.TabIndex = 4;
            BitgetLabel.Text = "Bitget:";
            // 
            // BitgetPrice
            // 
            BitgetPrice.AutoSize = true;
            BitgetPrice.Font = new Font("Segoe UI", 15F);
            BitgetPrice.Location = new Point(132, 79);
            BitgetPrice.Name = "BitgetPrice";
            BitgetPrice.Size = new Size(0, 35);
            BitgetPrice.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.Location = new Point(12, 114);
            label1.Name = "label1";
            label1.Size = new Size(102, 35);
            label1.TabIndex = 6;
            label1.Text = "Kucoin:";
            // 
            // KucoinPrice
            // 
            KucoinPrice.AutoSize = true;
            KucoinPrice.Font = new Font("Segoe UI", 15F);
            KucoinPrice.Location = new Point(132, 114);
            KucoinPrice.Name = "KucoinPrice";
            KucoinPrice.Size = new Size(0, 35);
            KucoinPrice.TabIndex = 7;
            // 
            // SetCoin
            // 
            SetCoin.FormattingEnabled = true;
            SetCoin.Location = new Point(12, 196);
            SetCoin.Name = "SetCoin";
            SetCoin.Size = new Size(152, 28);
            SetCoin.TabIndex = 8;
            SetCoin.SelectedIndexChanged += SetCoin_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(12, 173);
            label4.Name = "label4";
            label4.Size = new Size(109, 20);
            label4.TabIndex = 9;
            label4.Text = "Выбор тикета";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(SetCoin);
            Controls.Add(KucoinPrice);
            Controls.Add(label1);
            Controls.Add(BitgetPrice);
            Controls.Add(BitgetLabel);
            Controls.Add(BybitPrice);
            Controls.Add(label3);
            Controls.Add(BinancePrice);
            Controls.Add(BinanceLabel);
            Font = new Font("Segoe UI", 9F);
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label BinanceLabel;
        private Label BinancePrice;
        private Label label3;
        private Label BybitPrice;
        private Label BitgetLabel;
        private Label BitgetPrice;
        private Label label1;
        private Label KucoinPrice;
        private ComboBox SetCoin;
        private Label label4;
    }
}
