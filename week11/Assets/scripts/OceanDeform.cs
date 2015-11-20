using UnityEngine;
using System.Collections;

public class OceanDeform : MonoBehaviour {

	// the MeshFilter tells Unity what mesh we're using
	MeshFilter mFilter; // shortcut to meshFilter
	Vector3[] originalVertices; // once we start deforming the mesh, we won't remember it

	public float oceanHeight = 1f; // amplitude
	public float oceanSpeed = 1f; // frequency

	// Use this for initialization
	void Start () {
		// caching the shortcut
		mFilter = GetComponent<MeshFilter>();
		// cloning a pristine copy of our mesh for later
		originalVertices = mFilter.mesh.vertices.Clone() as Vector3[];
	}
	
	// Update is called once per frame
	void Update () {
		// make a new copy of the vertices to deform
		Vector3[] newVertices = originalVertices.Clone() as Vector3[];

		// go through the vertex array and do stuff to each vertex
		for ( int i=0; i<newVertices.Length; i++ ) {
			newVertices[i] += new Vector3( 0f, Mathf.Sin( (Time.time + i) * oceanSpeed) * oceanHeight, 0f );
		}

		// put the vertices back into the mesh
		Mesh deformedMesh = new Mesh();
		deformedMesh.vertices = newVertices; // NEW VERTICES!
		deformedMesh.triangles = mFilter.mesh.triangles; // old triangles
		deformedMesh.uv = mFilter.mesh.uv; // copy old UVs
		// deformedMesh.normals = mFilter.mesh.normals; // copy old normals
		deformedMesh.tangents = mFilter.mesh.tangents; // copy old tangents

		deformedMesh.RecalculateNormals(); // recalculate normals

		// put the mesh back into the mesh filter
		mFilter.mesh = deformedMesh;

		// put the mesh into the Mesh Collider too!
		GetComponent<MeshCollider>().sharedMesh = deformedMesh;

	}
}





