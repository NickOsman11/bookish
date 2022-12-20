import { useState } from 'react'
import reactLogo from './assets/react.svg'
import './App.css'
import { BooksPage } from './components/booksPage/BooksPage'

function App() {
  const [count, setCount] = useState(0)

  return (
    <div className="App">
        <h1>Hi Mum</h1>
        <BooksPage />
    </div>
  )
}

export default App
