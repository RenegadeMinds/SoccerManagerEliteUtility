using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

class TransparentDrawing : DrawingArea
{
    protected override void OnDraw()
    {
        //// Gets the image from the global resources
        //Image broculoImage = global::SoccerManagerEliteUtility.Properties.Resources.broculo;

        //// Sets the images' sizes and positions
        //int width = broculoImage.Size.Width;
        //int height = broculoImage.Size.Height;
        //Rectangle big = new Rectangle(0, 0, width, height);
        //Rectangle small = new Rectangle(50, 50, (int)(0.75 * width), (int)(0.75 * height));

        //// Draws the two images
        //this.graphics.DrawImage(broculoImage, big);
        //this.graphics.DrawImage(broculoImage, small);

        //// Sets the text's font and style and draws it
        //float fontSize = 8.25f;
        //Point textPosition = new Point(50, 100);
        //DrawText("http://www.broculos.net", "Microsoft Sans Serif", fontSize
        //    , FontStyle.Underline, Brushes.Blue, textPosition);
        if (this.BackgroundImage != null)
            this.graphics.DrawImage(this.BackgroundImage, new Point(0, 0));
    }
}
