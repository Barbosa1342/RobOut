using Cinemachine;
using UnityEngine;

public class Camera1 : MonoBehaviour
{
    /*
    Camera cam;
    [SerializeField] Transform cientista;
    [SerializeField] Transform robo;

    public float zoom = 1.5f;
    public float tempoSeguir = 0.8f;
    Vector3 pontoMedio;
    float distancia;

    Vector3 destinoCamera;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        pontoMedio = (cientista.position + robo.position) / 2f;
        distancia = (cientista.position - robo.position).magnitude;
        destinoCamera = pontoMedio - (distancia * zoom * cam.transform.forward);
        
        if (cam.orthographic){
            cam.orthographicSize = (distancia / 2);
        }

        cam.transform.position = Vector3.Slerp(cam.transform.position, destinoCamera, tempoSeguir);

        if ((destinoCamera - cam.transform.position).magnitude <= 0.05f){
            cam.transform.position = destinoCamera;
        }
    }
    */

    CinemachineVirtualCamera cam;
    [SerializeField] GameObject cientista;
    [SerializeField] GameObject robo;

    private Troca scriptCientista;

    private Transform transfCientista;
    private Transform transfRobo;

    void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();

        scriptCientista = cientista.GetComponent<Troca>();

        transfCientista = cientista.GetComponent<Transform>();
        transfRobo = robo.GetComponent<Transform>();
    }

    void Update(){
        if (scriptCientista.GetPodeAndar()){
            cam.Follow = transfCientista;
        }else{
            cam.Follow = transfRobo;
        }
    }
}
