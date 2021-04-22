using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PokemonClone.Engine;
using PokemonClone.Screen;
using System;

namespace PokemonClone.Actor
{
    public abstract class Character
    {
        protected Vector2 position;
        protected TextureRegion textureRegion;
        protected CharacterMovement characterMovement;
        protected CharaterCollision charaterCollision;
        protected CharacterAnimation characterAnimation;
        protected World world;
        protected Party party;
        public Direction direction = Direction.Idle;
        public Direction currentDirection = Direction.Idle;

        protected Character(World world, TextureRegion textureRegion, Vector2 position)
        {
            this.world = world;
            this.textureRegion = textureRegion;
            this.position = position;
            characterMovement = new CharacterMovement(this);
            charaterCollision = new CharaterCollision(this);
            characterAnimation = new CharacterAnimation(this, textureRegion);

            party = new Party();
            AlignToGrid();
        }

        public enum Direction
        {
            Up,
            Down,
            Left,
            Right,
            Idle
        }

        public virtual Vector2 Move(int x, int y)
        {
            if (charaterCollision.HasCollision(world, x, y) == false) //Aucune collision
            {
                position.X += x;
                position.Y += y;

                return position;
            }

            return position; //Retourne la position sans avoir avancer
        }

        public abstract void ChangerDirection(GameTime gameTime);

        public virtual Vector2 LerpPosition(Vector2 startPosition, Vector2 endPosition, float timer)
        {
            position = Vector2.Lerp(startPosition, endPosition, timer);
            return position;
        }

        public virtual void AlignToGrid()
        {                   
            //Aligne le joueur avec les tuiles de 16 x 16
            position.X -= position.X % 16;
            position.Y -= position.Y % 16;
            //Offset sur l'axe des X et Y pour centrer le joueur au milieux des tuiles.
            position.X -= 2;
            position.Y -= 6;

        }

        public virtual void Update(GameTime gameTime)
        {
            ChangerDirection(gameTime);
            characterMovement.Walk();
            characterAnimation.WalkAnimation(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBtach)
        {
            characterAnimation.Draw(spriteBtach, position);
        }


        public TextureRegion TextureRegion
        {
            get { return textureRegion; }
        }

        public float PositionX
        {
            get { return position.X; }
        }

        public float PositionY
        {
            get { return position.Y; }
        }

    }
}
