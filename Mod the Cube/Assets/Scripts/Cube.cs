using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private float _direction;
    float _scale;
    float _scaleStep = 0.1f;
    
    void Start()
    {        
        if (gameObject.layer == 6) { //cube 
            _scale = 1.2f;
        } else {
            _scale = 15f;
        }

        transform.position = Vector3.zero;
        transform.localScale = Vector3.one * _scale;        

        SetColor();
        SetDirection();
    }
    
    void LateUpdate()
    {
        Rotate();
        if (gameObject.layer == 6) { //cube 
            Move();    
        }        
    }

    void Rotate() 
    {
        float _speed = 100.0f;
        transform.Rotate(_speed * Time.deltaTime, 0.0f, 0.0f);
    }

    void Move()
    {
        float _speed = 20.0f;
        float _random = Random.Range(-1.0f, 1.0f);
        transform.Translate(new Vector3(Vector3.one.x * _direction, 0.0f, Vector3.one.z * _direction) * Time.deltaTime * _speed);
    }

    void SetDirection()
    {
        _direction = Random.Range(-1.0f, 1.0f);
    }

    void SetColor()
    {
        float _colorR = Random.Range(0.0f, 1.0f);
        float _colorG = Random.Range(0.0f, 1.0f);
        float _colorB = Random.Range(0.0f, 1.0f);
        float _colorA = Random.Range(0.5f, 1.0f);
        Material material = Renderer.material;
        
        material.color = new Color(_colorR, _colorG, _colorB, _colorA);
    }
    
    private void OnTriggerExit(Collider other) {
        if (other.name == "Sphere") {
            _direction = -_direction;
            SetColor();
        }        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 6) {
            _direction = -_direction;
            SetColor();        
            _scale -= _scaleStep;
            if (_scale < 0.1f) {
                Destroy(gameObject);
            }
            transform.localScale = Vector3.one * _scale; 
        }        
    }
}
