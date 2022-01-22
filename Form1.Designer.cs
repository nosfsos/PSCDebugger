
namespace ScriptDebugger
{
    partial class MainWindow
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
            this.open = new System.Windows.Forms.Button();
            this.addDebugLines = new System.Windows.Forms.Button();
            this.targetDirectory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(154, 34);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(115, 23);
            this.open.TabIndex = 0;
            this.open.Text = "Select Scripts Folder";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // addDebugLines
            // 
            this.addDebugLines.Location = new System.Drawing.Point(122, 132);
            this.addDebugLines.Name = "addDebugLines";
            this.addDebugLines.Size = new System.Drawing.Size(177, 73);
            this.addDebugLines.TabIndex = 1;
            this.addDebugLines.Text = "Add Debug Lines";
            this.addDebugLines.UseVisualStyleBackColor = true;
            this.addDebugLines.Click += new System.EventHandler(this.addDebugLines_Click);
            // 
            // targetDirectory
            // 
            this.targetDirectory.Location = new System.Drawing.Point(154, 78);
            this.targetDirectory.Name = "targetDirectory";
            this.targetDirectory.Size = new System.Drawing.Size(115, 23);
            this.targetDirectory.TabIndex = 2;
            this.targetDirectory.Text = "SelectTargetDirectory";
            this.targetDirectory.UseVisualStyleBackColor = true;
            this.targetDirectory.Click += new System.EventHandler(this.targetDirectory_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 290);
            this.Controls.Add(this.targetDirectory);
            this.Controls.Add(this.addDebugLines);
            this.Controls.Add(this.open);
            this.Name = "MainWindow";
            this.Text = "Debugger";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button open;
        private System.Windows.Forms.Button addDebugLines;
        private System.Windows.Forms.Button targetDirectory;
    }
}

