using UnityEngine;

namespace Lindon.MiniGame.DragDropPuzzle
{
    /// <summary>
    /// Represents an item in the puzzle game. Attach this script to a GameObject to make it a puzzle item.
    /// </summary>
    [AddComponentMenu("MiniGame/Puzzle/ItemGroup")]
    public class PuzzleItem : MonoBehaviour
    {
        [SerializeField, Tooltip("The data representing the puzzle piece.")] private PieceData m_Data;

        [Header("Reference")]
        [SerializeField, Tooltip("The puzzle piece attached to this item.")] private PuzzlePiece m_Piece;
        [SerializeField, Tooltip("The puzzle slot where this item belongs.")] private PuzzleSlot m_Slot;

        /// <summary>
        /// Initializes the puzzle piece with the data and slot.
        /// </summary>
        private void Start()
        {
            m_Piece.Initialize(m_Data, ref m_Slot);
        }

        private void OnValidate()
        {
            m_Piece.Initialize(m_Data, ref m_Slot);
        }

        private void OnDrawGizmos()
        {
            if (m_Slot != null)
            {
                Gizmos.DrawCube(m_Slot.transform.position, Vector3.one * m_Data.MinimumDistance);
            }
        }
    }
}
