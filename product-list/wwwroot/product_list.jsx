const Product = ({ p }) => <div className="col-md-3 product">
  <div className="row"><img src={'/assets/Products/' + p.productImage} /></div>
  <div className="row" style={{ height: '20px' }}><div className="col-md-12">
    {p.isSale && <span className="badge badge-secondary">Sale</span>}
    {p.isExclusive && <span className="badge badge-success">Exclusive</span>}</div>
  </div>
  <div className="row">
    <div className="col-md-8"><strong>{p.productName}</strong></div>
    <div className="col-md-4 pull-right"><strong>{p.price}</strong></div>
  </div>
</div>

const ProductList = ({ list }) => <div className="alert alert-light">
  {
    _.map(_.chunk(list, 4), (gp, i) => <div key={i} className="row">{
      _.map(gp, p => {
        return <Product key={p.index} p={p} />
      })
    }</div>)
  }

</div>

class App extends React.Component {

  constructor(props) {
    super(props);
    this.state = { size: '', list: [], loading: false };
  }

  componentWillMount() {
    this.refresh()
  }

  refresh() {
    this.setState({ loading: true }, () => this.fetchProducts().then(list => this.setState({ list, loading: false })))
  }

  async fetchProducts() {
    let list = await fetch('/Home/Products/' + this.state.size)
    return list.json()
  }

  render() {
    const { list, loading } = this.state

    return <div className="container-fluid"><br />

      <div className="container-fluid">

        <div className="row alert alert-info">
          <div className="col-md-8">
            <h3>Women's tops</h3>
          </div>
          <div className="col-md-4">
            <span className="pull-right"><select className="form-control" onChange={(e) => this.setState({ size: e.target.value }, this.refresh)} value={this.state.size}>
              <option value="">Filter by size</option>
              <option value="XS">XS</option>
              <option value="S">S</option>
              <option value="M">M</option>
              <option value="L">L</option>
              <option value="XL">XL</option>
            </select></span>

          </div>
        </div>

      </div>

      <div>
        {
          loading ? 'Loading...' : <ProductList list={list} />
        }
      </div>
    </div >
  }
}

ReactDOM.render(
  <App />,
  document.getElementById('root')
);