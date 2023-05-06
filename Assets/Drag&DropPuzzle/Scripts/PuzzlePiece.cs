using UnityEngine;

namespace Lindon.MiniGame.Puzzle
{
    [AddComponentMenu("MiniGame/Puzzle/Piece")]
    [RequireComponent(typeof(Collider2D))]
    public class PuzzlePiece : MonoBehaviour
    {
        private bool m_Dragging = false;
        private bool m_Placed = false;

        private Vector2 m_Offset;
        private Vector2 m_StartPosition;

        private PuzzleSlot m_Slot;

        public void Initialize(ref PuzzleSlot slot)
        {
            m_Slot = slot;

            var data = GetData();

            slot.SetPieceData(data);
        }

        private PuzzlePieceData GetData()
        {
            return new PuzzlePieceData();
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
            if (Vector2.Distance(transform.position, m_Slot.transform.position) < 3)
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
