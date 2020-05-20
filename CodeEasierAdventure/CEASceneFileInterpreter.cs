using CodeEasier.Polish;
using CodeEasier.Scene;
using EscapeCraft;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEasierAdventure
{
    class CEASceneFileInterpreter
    {

        private string[] lines;
        public SpriteFont Font { get; set; }
        public Main BaseGame { get; set; }

        public List<CEImageElement> ImageElements { get; set; }
        public List<CEATravelZone> TravelZones { get; set; }

        public List<ICEASceneObject> Objects { get; set; }

        private MouseState oldMouseState;

        private CETransition TransitionIn { get; set; }

        public CEASceneFileInterpreter(string filePath, SpriteFont font, Main baseGame)
        {

            Font = font;
            BaseGame = baseGame;

            ImageElements = new List<CEImageElement>();
            TravelZones = new List<CEATravelZone>();

            Objects = new List<ICEASceneObject>();

            ReadSceneFile(filePath);

        }

        private void ReadSceneFile(string path)
        {
            if (path.EndsWith(".scn"))
            {
                lines = System.IO.File.ReadAllLines(path);
            }
            else
            {
                throw new Exception("A scene file must have the extension .scn");
            }
        }

        private void ParseSceneFile()
        {

            ImageElements.Clear();
            TravelZones.Clear();

            foreach (string line in lines)
            {
                // remove blank lines and comments
                if (line != "" && !line.StartsWith("//"))
                {
                    string[] parts = line.Split(' ');
                    for (int i = 0; i < parts.Length; i++)
                    {
                        if (parts[i] == "Image" && parts[i + 1] == ":")
                        {
                            if (parts[i + 3] == "/" && parts[i + 7] == "/" && parts[i + 11] == "/" && parts[i + 15] == "/")
                            {
                                if (parts[i + 4] == "x" && parts[i + 8] == "y")
                                {
                                    if (parts[i + 12] == "width" && parts[i + 16] == "height")
                                    {
                                        string imageStr = parts[i + 2];
                                        string xStr = parts[i + 6];
                                        string yStr = parts[i + 10];
                                        string widthStr = parts[i + 14];
                                        string heightStr = parts[i + 18];

                                        string[] xParts = xStr.Split('/');
                                        string[] yParts = yStr.Split('/');

                                        int x = 0;
                                        int y = 0;

                                        if (xParts.Length == 2)
                                        {
                                            if (xParts[0] == "w")
                                            {
                                                x = BaseGame.game.ScreenWidth / Int32.Parse(xParts[1]);
                                            }

                                        }
                                        else if (xParts.Length == 1)
                                        {
                                            x = Int32.Parse(xParts[0]);
                                        }

                                        if (yParts.Length == 2)
                                        {
                                            if (yParts[0] == "h")
                                            {
                                                y = BaseGame.game.ScreenHeight / Int32.Parse(yParts[1]);
                                            }

                                        }
                                        else if (yParts.Length == 1)
                                        {
                                            y = Int32.Parse(yParts[0]);
                                        }

                                        CEImageElement image = new CEImageElement(BaseGame.Content.Load<Texture2D>(imageStr), new Rectangle(x, y, BaseGame.game.ScreenWidth / Int32.Parse(widthStr), BaseGame.game.ScreenHeight / Int32.Parse(heightStr)));

                                        ImageElements.Add(image);

                                    }
                                }
                            }
                        }
                        if (parts[i] == "TravelZone" && parts[i + 1] == ":")
                        {
                            int index = 0;
                            string[] partsForText = line.Split('"');
                            string text = partsForText[1];
                            int textLenth = text.Split(' ').Length;
                            if (parts[i + textLenth + 2] == "/" && parts[i + textLenth + 6] == "/" && parts[i + textLenth + 10] == "/" && parts[i + textLenth + 14] == "/" && parts[i + textLenth + 18] == "/" && parts[i + textLenth + 22] == "/")
                            {
                                if (parts[i + textLenth + 3] == "x" && parts[i + textLenth + 7] == "y" && parts[i + textLenth + 11] == "width" && parts[i + textLenth + 15] == "height" && parts[i + textLenth + 19] == "idtogo" && parts[i + textLenth + 23] == "cursor")
                                {

                                    string xStr = parts[i + textLenth + 5];
                                    string yStr = parts[i + textLenth + 9];
                                    string widthStr = parts[i + textLenth + 13];
                                    string heightStr = parts[i + textLenth + 17];
                                    string cursorStr = parts[i + textLenth + 25];

                                    string[] xParts = xStr.Split('/');
                                    string[] yParts = yStr.Split('/');

                                    float x = 0;
                                    float y = 0;

                                    string idToGo = parts[i + textLenth + 21];

                                    if (xParts.Length == 2)
                                    {
                                        if (xParts[0] == "w")
                                        {
                                            x = BaseGame.game.ScreenWidth / float.Parse(xParts[1]);
                                        }

                                    }
                                    else if (xParts.Length == 1)
                                    {
                                        x = float.Parse(xParts[0]);
                                    }

                                    if (yParts.Length == 2)
                                    {
                                        if (yParts[0] == "h")
                                        {
                                            y = BaseGame.game.ScreenHeight / float.Parse(yParts[1]);
                                        }

                                    }
                                    else if (yParts.Length == 1)
                                    {
                                        y = float.Parse(yParts[0]);
                                    }

                                    CEATravelZone travelZone = new CEATravelZone(new Rectangle((int) x, (int) y, BaseGame.game.ScreenWidth / Int32.Parse(widthStr), BaseGame.game.ScreenHeight / Int32.Parse(heightStr)), idToGo, text, Font, Color.White, cursorStr, BaseGame);

                                    TravelZones.Add(travelZone);

                                    index++;

                                }
                            }
                        }
                    }
                }

            }

        }

        public void Load()
        {
            ParseSceneFile();

            TransitionIn = new CETransition(2, CETransition.Type.In);

            oldMouseState = Mouse.GetState();

            foreach (ICEASceneObject o in Objects)
            {
                o.Load();
            }

        }

        public void Update(GameTime gameTime)
        {
            MouseState newMouseState = Mouse.GetState();

            ParseSceneFile();

            foreach (CEATravelZone t in TravelZones)
            {
                t.Update(newMouseState, oldMouseState);
            }

            if (TravelZones.TrueForAll(item => !item.IsHovered))
            {
                BaseGame.game.ShowSpecialCursor = false;
            }

            if (TransitionIn.Alpha > 0)
            {
                TransitionIn.Update(gameTime);
            }

            foreach (ICEASceneObject o in Objects)
            {
                o.Update(gameTime);
            }

            oldMouseState = newMouseState;

        }

        public void Draw()
        {

            foreach (CEImageElement i in ImageElements)
            {
                i.Draw(BaseGame.spriteBatch);
            }

            foreach (ICEASceneObject o in Objects)
            {
                o.Draw(BaseGame.spriteBatch);
            }

            foreach (CEATravelZone t in TravelZones)
            {
                t.Draw(BaseGame.spriteBatch);
            }

        }

        public void DrawTransitions()
        {
            TransitionIn.Draw(BaseGame);
        }

        public void AddObject(ICEASceneObject obj)
        {
            Objects.Add(obj);
        }

    }
}
