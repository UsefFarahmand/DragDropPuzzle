using UnityEngine;

namespace Lindon.MiniGame.DragDropPuzzle
{
    /// <summary>
    /// Represents a slot in the puzzle game. Attach this script to a GameObject to make it a puzzle slot.
    /// </summary>
    [AddComponentMenu("MiniGame/Puzzle/Slot")]
    [RequireComponent(typeof(SpriteRenderer))]
    public class PuzzleSlot : MonoBehaviour
    {
        /// <summary>
        /// Sets the sprite and scale of the puzzle slot to match the given piece data.
        /// </summary>
        /// <param name="pieceData">The data representing the puzzle piece.</param>
        public void SetPieceData(PieceData pieceData)
        {
            GetComponent<SpriteRenderer>().sprite = pieceData.Sprite;
            transform.localScale = pieceData.Scale;
        }
    }
}
