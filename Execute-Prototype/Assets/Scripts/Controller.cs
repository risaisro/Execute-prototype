using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    [Range(2, 10)]
    public int numVerticalRays;
    [Range(2, 10)]
    public int numHorizontalRays;

    public LayerMask Platforms;
    public LayerMask Triggers;

    [Range(0.01f, 0.1f)]
    public float skinWidth;

    private BoxCollider2D box;
    private float horizontalSpacing;
    private float verticalSpacing;

    public CollisionSide collision;

    private Vector2 topLeft, topRight, bottomLeft, bottomRight;



    // Use this for initialization
    void Start() {
        box = GetComponent<BoxCollider2D>();
        updateOriginPoints();
    }

    // Handles movement; checks for collisions and than translates sprites
    public void move(Vector2 velocity) {
        updateOriginPoints();
        calculateSpacing();
        collision.reset();

        if (velocity.y != 0) {
            verticalCollision(ref velocity);
        }

        if (velocity.x != 0) {
            horizontalCollision(ref velocity);
        }
        transform.Translate(velocity, Space.World);
    }


    // Raycast collision for horizontal movement
    private void horizontalCollision(ref Vector2 velocity) {
        Vector2 origin = velocity.x > 0 ? bottomRight : bottomLeft;
        Vector2 direction = new Vector2(Mathf.Sign(velocity.x), 0);
        float rayLength = Mathf.Abs(velocity.x) + skinWidth;
        for (int i = 0; i < numHorizontalRays; i++) {
            RaycastHit2D hit = Physics2D.Raycast(origin + Vector2.up * (horizontalSpacing * i), direction, rayLength, Platforms);
            //Debug.DrawRay(origin + Vector2.up * (horizontalSpacing * i), new Vector2(rayLength, 0));
            if (hit) {
                velocity.x = (hit.distance - skinWidth) * direction.x;
                rayLength = hit.distance;
                
            }
            //RaycastHit2D trigger = Physics2D.Raycast(origin + Vector2.up * (horizontalSpacing * i), direction, rayLength, Triggers);
        }
    }

    // Raycast collision for vertical movement
    private void verticalCollision(ref Vector2 velocity) {
        Vector2 origin = velocity.y > 0 ? topLeft : bottomLeft;
        Vector2 direction = new Vector2(0, Mathf.Sign(velocity.y));
        float rayLength = Mathf.Abs(velocity.y) + skinWidth;
        for (int i = 0; i < numVerticalRays; i++) {
            RaycastHit2D hit = Physics2D.Raycast(origin + Vector2.right * (verticalSpacing * i), direction, rayLength, Platforms);
            //Debug.DrawRay(origin + Vector2.right * (verticalSpacing * i), new Vector2(0, rayLength));
            if (hit) {
                velocity.y = (hit.distance - skinWidth) * direction.y;
                rayLength = hit.distance;
                if (direction == Vector2.down)
                    collision.floor = true;
                else
                    collision.ceiling = true;
            }
        }
    }

    // Update location of raycast origin points, ie the corners of the collision box
    private void updateOriginPoints() {
        Bounds bounds = box.bounds;
        bounds.Expand(skinWidth * -2f);
        topLeft = new Vector2(bounds.min.x, bounds.max.y);
        topRight = new Vector2(bounds.max.x, bounds.max.y);
        bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        bottomRight = new Vector2(bounds.max.x, bounds.min.y);
    }

    // Determine how far apart to space raycasts based on size of collision box and number or rays
    private void calculateSpacing() {
        Bounds bounds = box.bounds;
        bounds.Expand(skinWidth * -2f);
        horizontalSpacing = bounds.size.y / (numHorizontalRays - 1);
        verticalSpacing = bounds.size.x / (numVerticalRays - 1);
    }

    // Struct to conveniently store and reset current collision status
    public struct CollisionSide {
        public bool ceiling, floor, right, left;
        public void reset() {
            ceiling = floor = right = left = false;
        }
    }

}
