using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;         // Đối tượng (player) mà camera muốn theo dõi
    public Vector3 offset;           // Vị trí tương đối giữa camera và player
    public float smoothSpeed = 0.125f; // Tốc độ trơn tru khi di chuyển camera

    private void LateUpdate()
    {
        if (target == null)
            return;

        // Tính toán vị trí mới của camera
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Cập nhật vị trí của camera
        transform.position = smoothedPosition;
    }
}