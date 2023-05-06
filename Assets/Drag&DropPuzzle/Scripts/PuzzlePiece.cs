using UnityEngine;

namespace Lindon.MiniGame.DragDropPuzzle
{
    /// <summary>
    /// A MonoBehaviour that provides a puzzle piece.
    /// </summary>
    [AddComponentMenu("MiniGame/Puzzle/Piece")]
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class PuzzlePiece : MonoBehaviour
    {
        private bool m_Dragging = false;

        /// <summary>
        /// Defines this piece is placed in the correct position.
        /// </summary>
        private bool m_Placed = false;

        private Vector2 m_Offset;
        private Vector2 m_StartPosition;

        private PuzzleSlot m_Slot;

        private float m_MinimumDistance;

        /// <summary>
        /// Initializes the puzzle piece with the given data and slot.
        /// </summary>
        /// <param name="data">The data for the puzzle piece.</param>
        /// <param name="slot">The slot for the puzzle piece.</param>
        public void Initialize(PieceData data, ref PuzzleSlot slot)
        {
            m_Slot = slot;

            GetComponent<SpriteRenderer>().sprite = data.Sprite;
            transform.localScale = data.Scale;
            m_MinimumDistance = data.MinimumDistance;

            slot.SetPieceData(data);
        }

        private void Start()
        {
            m_Placed = false;
            m_Dragging = false;
            m_StartPosition = transform.position;
        }

        private void Update()
        {
            if (m_Placed) return;
            if (!m_Dragging) return;

            var mousePosition = GetMousePosition();

            transform.position = mousePosition - m_Offset;
        }

        private void OnMouseDown()
        {
            m_Dragging = true;

            m_Offset = GetMousePosition() - (Vector2)transform.position;
        }

        private Vector2 GetMousePosition()
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        private void OnMouseUp()
        {
            Vector2 placedPosition;
            if (Vector2.Distance(transform.position, m_Slot.transform.position) < m_MinimumDistance)
            {
                placedPosition = m_Slot.transform.position;
                m_Placed = true;
            }
            else
            {
                placedPosition = m_StartPosition;
                m_Dragging = false;
            }

            transform.position = placedPosition;
        }
    }
}
