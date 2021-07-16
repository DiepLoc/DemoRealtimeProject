const nameValidator = [
  { required: true, message: "Name is required" },
  { max: 50 },
  {
    validator: (_, value) =>
      value.trim() == ""
        ? Promise.reject(new Error("Name not empty"))
        : Promise.resolve(),
  },
];

const brandNameValidator = [{ required: true, message: "Brand is required" }];

const priceValidator = [
  { type: "integer", min: 0, max: 100000, required: true },
];

const priceFormatter = (value) =>
  `$ ${value}`.replace(/\B(?=(\d{3})+(?!\d))/g, ",");

const selectedOptionFilter = (input, option) =>
  option.children.toLowerCase().includes(input.toLowerCase());

export {
  nameValidator,
  brandNameValidator,
  priceValidator,
  priceFormatter,
  selectedOptionFilter,
};
