﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using AllInOneMono;

/* Copyright Nathan Saccon 2018
 * 
 * PROG2370: Final Project
 * 
 * Teacher: Steve Hendrikse
 * 
 * Date Started: November 12, 2018
 * Date Completed: December 7, 2018
 * 
 */

namespace NathanSacconFinalProject
{
    public class CreditScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Texture2D creditBackgound;
        public CreditScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = g.spriteBatch;
            creditBackgound = g.Content.Load<Texture2D>("Images/creditBackground");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(creditBackgound, Vector2.Zero, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}