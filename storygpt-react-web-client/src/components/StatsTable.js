import React, { useEffect, useState } from "react";
import Table from "react-bootstrap/Table";

export default function StatsTable({ url }) {
  const [stories, setStories] = useState([]);
  useEffect(() => {
    fetch(url)
      .then((response) => response.json())
      .then((stories) => setStories(stories))
      .catch((error) => console.log("Error fetching stories: ", error));
  }, [url]);

  return (
    <Table striped bordered hover>
      <thead>
        <tr>
          <th>#</th>
          <th>Content</th>
          <th>Created</th>
        </tr>
      </thead>
      <tbody>
        {stories.map((story, index) => (
          <tr key={story.id}>
            <td>{index + 1}</td>
            <td>{story.content}</td>
            <td>{Date(story.dateCreated).toLocaleString()}</td>
          </tr>
        ))}
      </tbody>
    </Table>
  );
}
