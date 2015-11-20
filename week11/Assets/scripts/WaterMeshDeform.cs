using UnityEngine;
using System.Collections;

public class WaterMeshDeform : MonoBehaviour {
	
	Vector3[] baseVertices; // variable to remember base vertex positions
	MeshFilter meshFilter;
	
	public float waveHeight = 0.5f;
	public float waveFreqDirection = 0.5f;
	public float waveSpeed = 2f;
	
	// Use this for initialization
	void Start () {
		meshFilter = GetComponent<MeshFilter>();
		baseVertices = meshFilter.mesh.vertices.Clone() as Vector3[];
	}
	
	// Update is called once per frame
	void Update () {
		// start with a fresh clean copy
		Vector3[] newVertices = baseVertices.Clone() as Vector3[];
		
		// apply sin wave to vertices
		for ( int i=0; i<newVertices.Length; i++ ) {
			newVertices[i] += Vector3.up * Mathf.Sin( (Time.time * waveSpeed + i) * waveFreqDirection) * waveHeight;
		}
		
		// make a new "Mesh" data container
		Mesh deformedMesh = new Mesh();
		deformedMesh.vertices = newVertices;
		deformedMesh.triangles = meshFilter.mesh.triangles;
		deformedMesh.uv = meshFilter.mesh.uv;
		deformedMesh.tangents = meshFilter.mesh.tangents;
		deformedMesh.RecalculateNormals ();
		
		// plug meshes back into components
		meshFilter.mesh = deformedMesh;
		GetComponent<MeshCollider>().sharedMesh = deformedMesh;
		
	} // closes out Update()
} // closes out the class