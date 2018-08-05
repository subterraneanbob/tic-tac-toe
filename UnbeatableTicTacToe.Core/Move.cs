namespace UnbeatableTicTacToe.GameCore
{
    public struct Move
    {
        public static readonly Move Invalid = new Move(0, 0, false);

        public byte Row { get; }
        public byte Column { get; }
        public bool Valid { get; }

        public Move(byte row, byte column) 
            : this(row, column, true)
        {
        }

        public Move(byte row, byte column, bool valid = true)
        {
            Row = row;
            Column = column;
            Valid = valid;
        }

        public static bool operator ==(Move move1, Move move2)
        {
            return move1.Equals(move2);
        }

        public static bool operator !=(Move move1, Move move2)
        {
            return !move1.Equals(move2);
        }

        public override bool Equals(object obj)
        {
            Move other = (Move)obj;

            return Row == other.Row && Column == other.Column && Valid == other.Valid;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Row.GetHashCode();
                hashCode = (hashCode * 397) ^ Column.GetHashCode();
                hashCode = (hashCode * 397) ^ Valid.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"({Row},{Column})";
        }
    }
}
