using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;

namespace MyGame
{
    public class PlayerController : SyncScript
    {
        public float Speed = 5.0f;
        private AnimationComponent _animationComponent;
        public override void Start()
        {
            _animationComponent = Entity.Get<AnimationComponent>();
        }
        public override void Update()
        {
            var input = Input;
            Vector3 move = Vector3.Zero;

            if (input.IsKeyDown(Keys.W)) move += Vector3.UnitZ;
            if (input.IsKeyDown(Keys.S)) move -= Vector3.UnitZ;
            if (input.IsKeyDown(Keys.A)) move += Vector3.UnitX;
            if (input.IsKeyDown(Keys.D)) move -= Vector3.UnitX;

            if (move.Length() > 1) move.Normalize();
            Entity.Transform.Position += move * Speed * (float)Game.UpdateTime.Elapsed.TotalSeconds;

            if (move != Vector3.Zero)
            {
                if (_animationComponent.IsPlaying("Idle") || !_animationComponent.IsPlaying("Run"))
                {
                    _animationComponent.Play("Run");
                }
            }
            else
            {
                if (_animationComponent.IsPlaying("Run") || !_animationComponent.IsPlaying("Idle"))
                {
                    _animationComponent.Play("Idle");
                }
            }
        }
    }
}
