using System.Collections.Generic;
using UnityEngine;

public class Model
{
    List<Vector3Int> faces = new List<Vector3Int>();
    List<Vector3> vertices = new List<Vector3>();

    public Model()
    {
        addVertices();
        addFaces();
    }

    private void addVertices() 
    {
        // Add the front face vertices
        vertices.Add(new Vector3(-2f, 4f, -1f)); // Vertex 0
        vertices.Add(new Vector3(2f, 4f, -1f)); // Vertex 1
        vertices.Add(new Vector3(-3f, 3f, -1f)); // Vertex 2
        vertices.Add(new Vector3(3f, 3f, -1f)); // Vertex 3
        vertices.Add(new Vector3(-2f, 2f, -1f)); // Vertex 4
        vertices.Add(new Vector3(-1f, 2f, -1f)); // Vertex 5
        vertices.Add(new Vector3(1f, 2f, -1f)); // Vertex 6
        vertices.Add(new Vector3(2f, 2f, -1f)); // Vertex 7
        vertices.Add(new Vector3(-1f, -3f, -1f)); // Vertex 8
        vertices.Add(new Vector3(1f, -3f, -1f)); // Vertex 9
        vertices.Add(new Vector3(0f, -4f, -1f)); // Vertex 10
        // Add the back face vertices
        vertices.Add(new Vector3(-2f, 4f, 1f)); // Vertex 11
        vertices.Add(new Vector3(2f, 4f, 1f)); // Vertex 12
        vertices.Add(new Vector3(-3f, 3f, 1f)); // Vertex 13
        vertices.Add(new Vector3(3f, 3f, 1f)); // Vertex 14
        vertices.Add(new Vector3(-2f, 2f, 1f)); // Vertex 15
        vertices.Add(new Vector3(-1f, 2f, 1f)); // Vertex 16
        vertices.Add(new Vector3(1f, 2f, 1f)); // Vertex 17
        vertices.Add(new Vector3(2f, 2f, 1f)); // Vertex 18
        vertices.Add(new Vector3(-1f, -3f, 1f)); // Vertex 19
        vertices.Add(new Vector3(1f, -3f, 1f)); // Vertex 20
        vertices.Add(new Vector3(0f, -4f, 1f)); // Vertex 21
    }

    private void addFaces()
    {
        // Add the front face triangles
        faces.Add(new Vector3Int(0, 2, 4)); // Face 0
        faces.Add(new Vector3Int(0, 4, 1)); // Face 1
        faces.Add(new Vector3Int(1, 4, 7)); // Face 2
        faces.Add(new Vector3Int(1, 7, 3)); // Face 3
        faces.Add(new Vector3Int(5, 9, 6)); // Face 4
        faces.Add(new Vector3Int(5, 8, 9)); // Face 5
        faces.Add(new Vector3Int(8, 10, 9)); // Face 6
        // Add the back face triangles
        faces.Add(new Vector3Int(11, 15, 13)); // Face 7
        faces.Add(new Vector3Int(12, 15, 11)); // Face 8
        faces.Add(new Vector3Int(12, 18, 15)); // Face 9
        faces.Add(new Vector3Int(12, 14, 18)); // Face 10
        faces.Add(new Vector3Int(17, 20, 16)); // Face 11
        faces.Add(new Vector3Int(16, 20, 19)); // Face 12
        faces.Add(new Vector3Int(20, 21, 19)); // Face 13
        // Add the top face triangles
        faces.Add(new Vector3Int(0, 1, 11)); // Face 14
        faces.Add(new Vector3Int(11, 1, 12)); // Face 15
        // Add the left face triangles
        faces.Add(new Vector3Int(2, 0, 11)); // Face 16
        faces.Add(new Vector3Int(2, 11, 13)); // Face 17
        faces.Add(new Vector3Int(4, 2, 13)); // Face 18
        faces.Add(new Vector3Int(4, 13, 15)); // Face 19
        faces.Add(new Vector3Int(5, 4, 15)); // Face 20
        faces.Add(new Vector3Int(5, 15, 16)); // Face 21
        faces.Add(new Vector3Int(8, 5, 16)); // Face 22
        faces.Add(new Vector3Int(8, 16, 19)); // Face 23
        faces.Add(new Vector3Int(10, 8, 19)); // Face 24
        faces.Add(new Vector3Int(10, 19, 21)); // Face 25
        // Add the right face triangles
        faces.Add(new Vector3Int(12, 1, 3)); // Face 26
        faces.Add(new Vector3Int(12, 3, 14)); // Face 27
        faces.Add(new Vector3Int(14, 3, 7)); // Face 28
        faces.Add(new Vector3Int(14, 7, 18)); // Face 29
        faces.Add(new Vector3Int(7, 6, 18)); // Face 30
        faces.Add(new Vector3Int(6, 17, 18)); // Face 31
        faces.Add(new Vector3Int(17, 6, 9)); // Face 32
        faces.Add(new Vector3Int(17, 9, 20)); // Face 33
        faces.Add(new Vector3Int(20, 9, 10)); // Face 34
        faces.Add(new Vector3Int(20, 10, 21)); // Face 35

    }

    public GameObject CreateUnityGameObject()
    {
        Mesh mesh = new Mesh();
        GameObject newGO = new GameObject();

        MeshFilter mesh_filter = newGO.AddComponent<MeshFilter>();
        MeshRenderer mesh_renderer = newGO.AddComponent<MeshRenderer>();

        List<Vector3> coords = new List<Vector3>();
        List<int> dummy_indices = new List<int>();
        /*List<Vector2> text_coords = new List<Vector2>();
        List<Vector3> normalz = new List<Vector3>();*/
        //fghfg
        for (int i = 0; i < faces.Count; i++)
        {
            //Vector3 normal_for_face = normals[i];

            //normal_for_face = new Vector3(normal_for_face.x, normal_for_face.y, -normal_for_face.z);

            coords.Add(vertices[faces[i].x]); dummy_indices.Add(i * 3); //text_coords.Add(texture_coordinates[texture_index_list[i].x]); normalz.Add(normal_for_face);

            coords.Add(vertices[faces[i].y]); dummy_indices.Add(i * 3 + 2); //text_coords.Add(texture_coordinates[texture_index_list[i].y]); normalz.Add(normal_for_face);

            coords.Add(vertices[faces[i].z]); dummy_indices.Add(i * 3 + 1); //text_coords.Add(texture_coordinates[texture_index_list[i].z]); normalz.Add(normal_for_face);
        }

        mesh.vertices = coords.ToArray();
        mesh.triangles = dummy_indices.ToArray();
        /*mesh.uv = text_coords.ToArray();
        mesh.normals = normalz.ToArray();*/
        mesh_filter.mesh = mesh;

        return newGO;
    }
}
