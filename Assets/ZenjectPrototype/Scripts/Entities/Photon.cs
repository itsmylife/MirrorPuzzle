﻿using System;
using UnityEngine;
using Zenject;
using ZenjectPrototype.Entities.Capabilities;

namespace ZenjectPrototype.Entities
{
    public class Photon : Entity, IKillable, IMovable, IRotatable
    {
        private IRotatable rotatable; // Changeable rotation logic
        private IMovable movement; // Changable movement logic

        public Vector3 Rotation
        {
            get
            {
                return rotatable.Rotation;
            }
            set
            {
                rotatable.Rotation = value;
            }
        }

        public Vector3 Velocity
        {
            get { return movement.Velocity; }
            set { movement.Velocity = value; }
        }

        [Inject]
        public void Construct(IMovable movement, IRotatable rotatable)
        {
            this.movement = movement;
            this.rotatable = rotatable;
        }

        public void Kill()
        {
            Destroy(gameObject);
        }

        public void Move()
        {
            movement.Move(); // Method delegation
        }

        public void Rotate(Vector3 amount)
        {
            rotatable.Rotate(amount); // Method delegation
        }

        public void LookAt(Vector3 position)
        {
            rotatable.LookAt(position); // Method delegation
        }

        public class Factory : Factory<Photon> { }
    }
}

