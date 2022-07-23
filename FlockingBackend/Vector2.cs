using System;

namespace FlockingBackend {
    public struct Vector2 {
        public float Vx { get; }
        public float Vy { get; }

        public Vector2(float vx, float vy) {
            this.Vx = vx;
            this.Vy = vy;
        }

        public static Vector2 operator+ (Vector2 v1, Vector2 v2) {
            return new Vector2(v1.Vx + v2.Vx, v1.Vy + v2.Vy);
        }
 
        public static Vector2 operator- (Vector2 v1, Vector2 v2) {
            return new Vector2(v1.Vx - v2.Vx, v1.Vy - v2.Vy);
        }

        // Divide Vector by scalar
        public static Vector2 operator/ (Vector2 v1, float s) {
            if (s == 0f) {
                return v1;
            }
            return new Vector2(v1.Vx / s, v1.Vy / s);
        }

        // Multiply Vector by Scalar
        public static Vector2 operator* (Vector2 v1, float s) {
            return new Vector2(v1.Vx * s, v1.Vy * s);
        }

        public static float DistanceSquared(Vector2 v1, Vector2 v2) {
            return (float)Math.Sqrt(((v1.Vx - v2.Vx) * (v1.Vx - v2.Vx)) + ((v1.Vy - v2.Vy) * (v1.Vy - v2.Vy)));
        }

        public static Vector2 Normalize(Vector2 v1) {
            // Calculate magnitude
            float m = (float)Math.Sqrt((v1.Vx * v1.Vx) + (v1.Vy * v1.Vy));
            return new Vector2(v1.Vx / m, v1.Vy / m);
        }

        public override string ToString() {
            return "(" + this.Vx + ", " + this.Vy + ")";
        }
    }
}