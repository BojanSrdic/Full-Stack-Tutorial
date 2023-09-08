import "./App.css";
import CryptoCoinList from "./components/CryptoCoinList/CryptoCoinList";

function App() {
  return (
    <>
      <article className="article-header">
        <header>
          <h1>React: Simple CRUD Application</h1>
        </header>
      </article>

      <section className="section-content">
        <CryptoCoinList/>
      </section>
    </>
  );
}

export default App;
