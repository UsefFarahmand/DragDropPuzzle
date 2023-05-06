using UnityEngine;

namespace Lindon.MiniGame.DragDropPuzzle
{
    /// <summary>
    /// A struct that specifies the information required for a puzzle piece.
    /// </summary>
    [System.Serializable]
    public struct PieceData
    {
        [SerializeField, Tooltip("The sprite of the puzzle piece.")]
        private Sprite m_Sprite;
        [SerializeField, Tooltip("The scale of the puzzle piece.")]
        private Vector3 m_Scale; 
        [SerializeField, Tooltip("The minimum acceptable distance between the puzzle piece and its slot.")]
        private float m_MinimumDistance; 

        /// <summary>
        /// Initializes a new instance of the PieceData struct with the specified sprite, scale, and minimum distance.
        /// </summary>
        /// <param name="sprite">The sprite of the puzzle piece.</param>
        /// <param name="scale">The scale of the puzzle piece.</param>
        /// <param name="minimumDistance">The minimum acceptable distance between the puzzle piece and its slot.</param>
        public PieceData(Sprite sprite, Vector3 scale, float minimumDistance)
        {
            m_Sprite = sprite;
            m_Scale = scale;
            m_MinimumDistance = minimumDistance;
        }

        /// <summary>
        /// Gets the sprite of the puzzle piece.
        /// </summary>
        public Sprite Sprite => m_Sprite;
        /// <summary>
        /// Gets the scale of the puzzle piece.
        /// </summary>
        public Vector3 Scale => m_Scale;
        /// <summary>
        /// Gets the minimum acceptable distance between the puzzle piece and its slot.
        /// </summary>
        public float MinimumDistance => m_MinimumDistance;
    }
}
