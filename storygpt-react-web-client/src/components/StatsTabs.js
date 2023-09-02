import { Tab, Tabs } from "react-bootstrap";
import StatsTable from "./StatsTable";

export default function StatsTabs() {
  return (
    <Tabs defaultActiveKey="last10" id="statsTabs" className="mb-3">
      <Tab eventKey="last10" title="Last 10 Stories">
        <StatsTable url="https://storygpt-api.azurewebsites.net/api/story/last10" />
      </Tab>
      <Tab eventKey="top10" title="Top 10 Stories">
        <StatsTable url="https://storygpt-api.azurewebsites.net/api/story/last10" />
      </Tab>
      <Tab eventKey="hot10" title="Hot 10 Stories">
        <StatsTable url="https://storygpt-api.azurewebsites.net/api/story/last10" />
      </Tab>
    </Tabs>
  );
}
