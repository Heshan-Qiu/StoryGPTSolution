import "bootstrap/dist/css/bootstrap.min.css";
import "./App.css";
import Ratio from "react-bootstrap/Ratio";

import { Container } from "react-bootstrap";
import StatsTabs from "./components/StatsTabs";
import { useEffect } from "react";

function App() {
  useEffect(() => {
    document.title = "storyGPT - AI Funny Stories";
  }, []);

  return (
    <Container className="App">
      <header className="App-header">
        <h1>storyGPT</h1>
        <p>AI generated funny stories with GPT-3</p>
        <div style={{ width: 660, height: "auto" }}>
          <Ratio aspectRatio="16x9">
            <embed
              type="image/svg+xml"
              src="https://youtube.com/embed/niCQ4Y2ru6g"
              title="storyGPT video"
            />
          </Ratio>
        </div>
      </header>
      <StatsTabs />
    </Container>
  );
}

export default App;
