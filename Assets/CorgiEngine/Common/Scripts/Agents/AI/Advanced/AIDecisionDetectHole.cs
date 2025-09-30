using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.CorgiEngine
{
    /// <summary>
    /// This Decision will return true if any object on its TargetLayer layermask enters its line of sight. It will also set the Brain's Target to that object. You can choose to have it in ray mode, in which case its line of sight will be an actual line (a raycast), or have it be wider (in which case it'll use a spherecast). You can also specify an offset for the ray's origin, and an obstacle layer mask that will block it.
    /// </summary>
	[AddComponentMenu("Corgi Engine/Character/AI/Decisions/AI Decision Detect Hole")]
    // [RequireComponent(typeof(Character))]
    public class AIDecisionDetectHole : AIDecision
    {
        /// the possible detection methods
        public enum DetectMethods { Ray, WideRay }
        /// the possible detection directions
        public enum DetectionDirections { Front, Back, Both }
        /// the detection method
        [Tooltip("the detection method (ray casts a single ray, wideray casts a boxcast")]
        public DetectMethods DetectMethod = DetectMethods.Ray;
        /// the detection direction
        [Tooltip("the detection direction (front, back, or both)")]
        public DetectionDirections DetectionDirection = DetectionDirections.Front;
        /// the width of the ray to cast (if we're in WideRay mode only
        [Tooltip("the width of the ray to cast (if we're in WideRay mode only")]
        public float RayWidth = 1f;
        /// the distance up to which we'll cast our rays
        [Tooltip("the distance up to which we'll cast our rays")]
        public float DetectionDistance = 10f;
        /// the offset to apply to the ray(s)
        [Tooltip("the offset to apply to the ray(s)")]
        public Vector3 DetectionOriginOffset = new Vector3(0,0,0);
        /// the layer(s) on which we want to search a target on
        [Tooltip("the layer(s) on which we want to search a target on")]
        public LayerMask TargetLayer = LayerManager.PlayerLayerMask;
        /// the layer(s) on which obstacles are set. Obstacles will block the ray
        [Tooltip("the layer(s) on which obstacles are set. Obstacles will block the ray")]
        public LayerMask ObstaclesLayer = LayerManager.ObstaclesLayerMask;

        //Código añadido


        public LayerMask ObstaclesLayermask = LayerManager.ObstaclesLayerMask;
        /// the length of the horizontal raycast we should use to detect obstacles that may cause a direction change
        


        [Tooltip("Whether to use a custom layermask, or simply use the platform mask defined at the character level")]
        public bool UseCustomLayermask = false;
        /// if using a custom layer mask, the list of layers considered as obstacles by this AI

        [Tooltip("If set to true, the agent will try and avoid falling")]
        protected bool AvoidFalling = true;
        [Tooltip("The offset the hole detection should take into account")]
        public Vector3 HoleDetectionOffset = new Vector3(0, 0, 0);
        /// the length of the ray cast to detect holes
        [Tooltip("the length of the ray cast to detect holes")]
        public float HoleDetectionRaycastLength = 1f;
        protected CorgiController _controller;


        protected Vector2 _direction;
        protected Vector2 _facingDirection;
        protected float _distanceToTarget;
        protected Vector2 _raycastOrigin;
        protected Character _character;
        protected bool _drawLeftGizmo = false;
        protected bool _drawRightGizmo = false;
        protected Color _gizmosColor = Color.yellow;
        protected Vector3 _gizmoCenter;
        protected Vector3 _gizmoSize;
        protected bool _init = false;
        protected Vector2 _boxcastSize = Vector2.zero;
        protected RaycastHit2D _raycastHit2D;

        /// The minimum duration, in seconds, after which to return true
        [Tooltip("The minimum duration, in seconds, after which to return true")]
        public float AfterTimeMin = 2f;
        /// The maximum duration, in seconds, after which to return true
        [Tooltip("The maximum duration, in seconds, after which to return true")]
        public float AfterTimeMax = 2f;

        protected float _randomTime;




        /// <summary>
        /// On Init we grab our character
        /// </summary>
        public override void Initialization()
        {
            _character = this.gameObject.GetComponentInParent<Character>();
            _controller = GetComponentInParent<CorgiController>();
            _gizmosColor.a = 0.25f;
            _init = true;
            RandomizeTime();
        }

        public override void OnEnterState()
        {
            base.OnEnterState();
            RandomizeTime();
        }

        /// <summary>
        /// On Decide we look for a target
        /// </summary>
        /// <returns></returns>
        public override bool Decide()
        {
            return CheckForHoles();
        }

        


        //Código añadido

        protected virtual bool CheckForHoles()
        {
            // if we're not grounded or if we're not supposed to check for holes, we do nothing and exit
            if (!AvoidFalling || !_controller.State.IsGrounded)
            {
                return false;
            }

            // we send a raycast at the extremity of the character in the direction it's facing, and modified by the offset you can set in the inspector.

            if (_character.IsFacingRight)
            {
                _raycastOrigin = transform.position + (_controller.Bounds.x / 2 + HoleDetectionOffset.x) * transform.right + HoleDetectionOffset.y * transform.up;
            }
            else
            {
                _raycastOrigin = transform.position - (_controller.Bounds.x / 2 + HoleDetectionOffset.x) * transform.right + HoleDetectionOffset.y * transform.up;
            }

            if (UseCustomLayermask)
            {
                _raycastHit2D = MMDebug.RayCast(_raycastOrigin, -transform.up, HoleDetectionRaycastLength, ObstaclesLayermask, Color.gray, true);
            }
            else
            {
                _raycastHit2D = MMDebug.RayCast(_raycastOrigin, -transform.up, HoleDetectionRaycastLength, _controller.PlatformMask | _controller.MovingPlatformMask | _controller.OneWayPlatformMask | _controller.MovingOneWayPlatformMask, Color.gray, true);
            }

            // if the raycast doesn't hit anything
            if (!_raycastHit2D)
            {
                // we change direction
                if (_brain == null) { return false; }
                return (_brain.TimeInThisState >= _randomTime);

            }
            else
            {

                return false;
                
            }
        }

        protected virtual void RandomizeTime()
        {
            _randomTime = Random.Range(AfterTimeMin, AfterTimeMax);
            
        }

        
    }
}
