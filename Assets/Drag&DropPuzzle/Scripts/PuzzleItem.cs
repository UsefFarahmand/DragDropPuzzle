using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lindon.MiniGame.Puzzle
{
    [AddComponentMenu("MiniGame/Puzzle/ItemGroup")]
    public class PuzzleItem : MonoBehaviour
    {
        [SerializeField] private PuzzlePiece m_Piece;
        [SerializeField] private PuzzleSlot m_Slot;

        private void Start()
        {
            m_Piece.Initialize(ref m_Slot);
        }
    }
}
