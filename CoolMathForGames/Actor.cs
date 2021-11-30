using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace Sick_Ship
{
    class Actor
    {
        private string _name;
        private bool _started;
        private Collider _collider;
        private Matrix3 _globalTransform = Matrix3.Identity;
        private Matrix3 _localTransform = Matrix3.Identity;
        private Matrix3 _translation = Matrix3.Identity;
        private Matrix3 _rotation = Matrix3.Identity;
        private Matrix3 _scale = Matrix3.Identity;
        private Actor[] _children = new Actor[0];
        private Actor _parent = null;
        private Sprite _sprite;


        private bool _alive = true;

        public bool Alive { get { return _alive; } set { _alive = value; } }

        /// <summary>
        /// True if the start function has been called for this actor
        /// </summary>
        public bool Started { get { return _started; } }

        /// <summary>
        /// Actos name
        /// </summary>
        public string Name { get { return _name; } }

        /// <summary>
        /// Sets new forward based on the direction turning
        /// </summary>
        public Vector2 Forward { get { return new Vector2(_rotation.M00, _rotation.M10); } 
                                 set {
                                        Vector2 point = value.Normalzed + WorldPosition;
                                        LookAt(point);
                                     } }

        /// <summary>
        /// Postion based on the local postion of the actor in conjuction
        /// if they have a parent or not
        /// </summary>
        public Vector2 LocalPosition { get { return new Vector2(_translation.M02, _translation.M12); } 
                                       set { SetTranslation(value.X, value.Y); } }

        public Vector2 WorldPosition
        {
            //Return the global transform's T column
            get { return new Vector2(GlobalTransform.M02, GlobalTransform.M12); }
            set
            {
                //If the parent isn't null...
                if (Parent != null)
                {
                    //...Convert the world cooridinates into local cooridinates and translate the actor
                    float xOffset = (value.X - Parent.WorldPosition.X) / new Vector2(GlobalTransform.M00, GlobalTransform.M10).Magnitude;
                    float yOffset = (value.Y - Parent.WorldPosition.Y) / new Vector2(GlobalTransform.M10, GlobalTransform.M11).Magnitude;
                    SetTranslation(xOffset, yOffset);
                }
                //If this actor doesnt have a parent...
                else
                {
                    //...Set the position to be the given value
                    LocalPosition = value;
                }

            }

        }

        /// <summary>
        /// Global representation Translation * Rotation * Scale 
        /// </summary>
        public Matrix3 GlobalTransform { get { return _globalTransform; } private set { _globalTransform = value; } }

        /// <summary>
        /// Local Repesentation based of the parent
        /// </summary>
        public Matrix3 LocalTransform { get { return _localTransform; } private set { _localTransform = value; } }

        /// <summary>
        /// Parent Actor
        /// </summary>
        public Actor Parent { get { return _parent; } set { _parent = value; } }

        /// <summary>
        /// Conditional Children of the parent 
        /// </summary>
        public Actor[] Children { get { return _children; } set { _children = value; } }

        /// <summary>
        /// Scaling size of the actor
        /// </summary>
        public Vector2 Size { get { return new Vector2(_scale.M00, _scale.M11); } set { SetScale(value.X, value.Y); } }

        /// <summary>
        /// Type of collision 
        /// for Circular collisiob 
        /// to AABB collision
        /// </summary>
        public Collider Collider { get { return _collider; } set { _collider = value; } }

        /// <summary>
        /// Image the actor imposes as
        /// </summary>
        public Sprite Sprite { get { return _sprite; } set { _sprite = value; } }

        public Actor(Vector2 position, string name = "Actor", string path = "")
        {
            _name = name;
            LocalPosition = position;
            if(path != "")
                _sprite = new Sprite(path);
        }

        /// <summary>
        /// Constructor 
        /// The classification of what it means to be a actor in 
        /// my game 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="name"></param>
        /// <param name="path"></param>
        public Actor(float x, float y, string name = "Actor", string path = "") :
            this (new Vector2 { X = x, Y = y }, name, path)
        { }

        public Actor() { }

        public virtual void Start()
        {
            _started = true;
        }
        
        /// <summary>
        /// Update once per frame 
        /// </summary>
        /// <param name="deltaTime"></param>
        public virtual void Update(float deltaTime)
        {
            UpdateTransform();

            Console.WriteLine(Name + " Position: X = " + GlobalTransform.M02 + " Y = " + GlobalTransform.M12);
        }

        /// <summary>
        /// Draws Out To The Consoole
        /// </summary>
        public virtual void Draw()
        {
            if (_sprite != null)
                _sprite.Draw(GlobalTransform);

            
        }

        public virtual void End()
        {

        }

        /// <summary>
        /// Updates Childs Transform In Colrallastion To the Parents 
        /// Orgin
        /// </summary>
        public void UpdateTransform()
        {
            //Concatnates the translation, rotation and scale to the actors local transforms 
            LocalTransform = _translation * _rotation * _scale;
            //if the parent is not equal to null. . .
            if (Parent != null)
                //. . .Global Transform will be set to the Parents global transform x the actors local transfrom
                GlobalTransform = Parent.GlobalTransform * LocalTransform;
            //else . . .
            else
                //. . .The Global transform is equal to LocalTransform
                GlobalTransform = LocalTransform;

        }

        /// <summary>
        /// Adds Children to our Private Actor Array 
        /// </summary>
        /// <param name="child"></param>
        public void AddChild(Actor child)
        {
            //creats a tamparay actor array by the size of children array plus 1
            Actor[] temp = new Actor[Children.Length + 1];
            //for every actor in the actor array 
            for (int i = 0; i < Children.Length; i++)
                //Adds all the children to the temp array 
                temp[i] = Children[i];
            //Set the added size to be the new child being added 
            temp[Children.Length] = child;
            //Sets the child to be the the twmp array 
            Children = temp;
            //Sets the child parent to be this actor
            child.Parent = this;

        }

        /// <summary>
        /// Removes Character the Arrays 
        /// </summary>
        /// <param name="child"></param>
        public bool RemoveChild(Actor child)
        {
            //A check to see if the child was removed
            bool removed = false;
            Actor[] temp = new Actor[Children.Length - 1];
            //Will idarate thriugh the temp array 
            int j = 0;
            for (int i = 0; i < Children.Length; i++)
            {   
                //if the child is not a part of the childrens array
                if (Children[i] != child)
                {
                    // It'll be added to the temporary array 
                    temp[j] = Children[i];
                    //Incraments by one
                    j++;
                }
                //else. . .
                else
                    //Sets the remove check to be true
                    removed = true;
            }
            //IF the remove check is true
            if (removed)
                //Sets the Children's array to be the temp array
                Children = temp;
            //Returns if actor was removed or not 
            return removed;
            
        }

        /// <summary>
        /// Checks if this actor collides with another 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public virtual bool CheckForCollision(Actor other)
        {
            if(other != null)
                if (Collider == null || other.Collider == null)
                    return false;

            return Collider.CheckCollision(other);
        }

        /// <summary>
        /// Applies the given values to the current translation
        /// </summary>
        /// <param name="transkationX">The amount to move on the x</param>
        /// <param name="translationY">The amount to move on the y</param>
        public void SetTranslation(float transkationX, float translationY)
        {
            _translation = Matrix3.CreateTranslation(transkationX,translationY);
        }

        /// <summary>
        /// Hard tanslate on base on the 
        /// </summary>
        /// <param name="translationX"></param>
        /// <param name="translationY"></param>
        public void Translate(float translationX, float translationY)
        {
            _translation *= Matrix3.CreateTranslation(translationX, translationY);
        }

        /// <summary>
        /// Hard set the rotation on raduians 
        /// </summary>
        /// <param name="radians"></param>
        public void SetRoation(float radians)
        {
            _rotation = Matrix3.CreateRotation(radians);
        }

        /// <summary>
        /// Rotatas the sprite based on how man raidans 
        /// </summary>
        /// <param name="radians"></param>
        public void Rotate(float radians)
        {
            _rotation *= Matrix3.CreateRotation(radians);
        } 

        /// <summary>
        /// Base condition if there is a collision
        /// 
        /// </summary>
        /// <param name="actor"></param>
        public virtual void OnCollision( Actor actor)
        {
            SceneManager.CloseApplication();
        }

        public void SetScale(float x, float y)
        {
            _scale = Matrix3.CreateScale(x, y);

        }

        /// <summary>
        /// Scales the actor by the 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Scale(float x,float y)
        {
            _scale *= Matrix3.CreateScale(x, y);
        }
        
        /// <summary>
        /// Rotates the actor at any given postion
        /// </summary>
        /// <param name="position"></param>
        public void LookAt(Vector2 position)
        {
            //Find the direction the actor should look in
            Vector2 direction = (position - WorldPosition).Normalzed;

            //Use the dot product to find the andle the actor needs to rotate 
            float dotProd = Vector2.DotProduct(direction, Forward);

            if (dotProd > 1)
                dotProd = 1;

            float angle = (float)Math.Acos(dotProd);

            //Perpendiculer Direction
            //Finds perpindicular vector to the direction
            Vector2 perpDirection = new Vector2(direction.Y, -direction.X);

            //Perpendicular Dot-Product 
            //Find the dot product of the perpindicular vector and current forward
            float perpDot = Vector2.DotProduct(perpDirection, Forward);

            //If the result isn't 0, use it to change the sign of the angle to be either positiove or negative
            if (perpDot != 0)
                angle *= -perpDot / Math.Abs(perpDot);

            Rotate(angle);
        }

    }
}
