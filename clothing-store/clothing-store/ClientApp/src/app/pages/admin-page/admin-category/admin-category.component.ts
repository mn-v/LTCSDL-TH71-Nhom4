import { Component, OnInit, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
declare var $:any;

@Component({
  selector: 'app-admin-category',
  templateUrl: './admin-category.component.html',
})
export class AdminCategoryComponent implements OnInit {

  categories: any = {
    data: [],
    totalRecord: 0,
    page: 1,
    size: 10,
    totalPages: 0,
  };

  category: any = {
    categoryId: 1,
    categoryName: "",
    title: "",
    description: "",
    gender: true,
    gioiTinh: "",
  };

  key :any = "";
  isEdit: boolean = true;

  constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl: string) {}

  ngOnInit() {
    this.searchCategory(1);
  }

  // hien thi danh sach loai san pham
  searchCategory(cPage) {
    let x = {
      page: cPage,
      size: 10,
      keyword: this.key
    };
    this.http
      .post("https://localhost:44320/" + "api/Categories/search-category", x)
      .subscribe(
        (result) => {
          this.categories = result;
          this.categories = this.categories.data;
          console.log(this.categories);
        },
        (error) => console.error(error)
      );
  }

  searchNext() {
    if (this.categories.page < this.categories.totalPages) {
      let nextPage = this.categories.page + 1;
      let x = {
        page: nextPage,
        size: 10,
        keyword: this.key
      };
      this.http
        .post("https://localhost:44320/api/Categories/search-category", x)
        .subscribe(
          (result) => {
            this.categories = result;
            this.categories = this.categories.data;
          },
          (error) => console.error(error)
        );
    } else {
      alert("Bạn đang ở trang cuối cùng!");
    }
  }

  searchPrevious() {
    if (this.categories.page > 1) {
      let nextPage = this.categories.page - 1;
      let x = {
        page: nextPage,
        size: 10,
        keyword: this.key
      };
      this.http
        .post("https://localhost:44320/api/Categories/search-category", x)
        .subscribe(
          (result) => {
            this.categories = result;
            this.categories = this.categories.data;
          },
          (error) => console.error(error)
        );
    } else {
      alert("Bạn đang ở trang đầu tiên!");
    }
  }

  //modal xoa
  deleteModal(index)
  {
    this.category = index;
    $('#myModal').modal("show");
  }

  // modal them va sua
  openModal(isNew, index)
  {
    if(isNew)
    {
      this.isEdit = false
      this.category={
        categoryName: "",
        title: "",
        description: "",
        gender: false,
      }
    }
    else
    {
      this.isEdit = true;
      this.category = index;
    }
    $('#Modal').modal("show");
  }

  //sau khi them sua xoa se an dialog va refresh lai trang bang ham location.reload()
  // them
  addCategory()
  {
    var x = this.category;
    this.http.post('https://localhost:44320/api/Categories/create-category', x).subscribe(result=>{
        var res:any = result;
        if(res.success){
          this.category = res.data;
          this.isEdit = true;
          alert("New product have been added successfully!");
          $('#Modal').modal("hide");
          location.reload();
        }
      }, error => console.error(error));
  }

  //sua
  updateCategory()
  {
    var x = this.category;
    this.http.post('https://localhost:44320/api/Categories/update-category', x).subscribe(result=>{
        var res:any = result;
        if(res.success){
          this.category = res.data;
          this.isEdit = true;
          alert("New product have been saved successfully!");
          $('#Modal').modal("hide");
          location.reload();
        }
      }, error => console.error(error));
  }

  //xoa
  deleteCategory(index)
  {
    var x = index;
    this.http.post('https://localhost:44320/api/Categories/delete-category', x).subscribe(result=>{
        var res:any = result;
        if(res.success){
          alert("New product have been deleted successfully!");
          $('#myModal').modal("hide");
          location.reload();
        }
      }, error => console.error(error));
  }
}
